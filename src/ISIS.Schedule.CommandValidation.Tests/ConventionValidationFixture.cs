using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using FluentValidation;
using Ncqrs.Spec;
using NUnit.Framework;

namespace ISIS.Schedule
{
    [Specification]
    public abstract class ConventionValidationFixture<T> :
        ValidationFixture<T>
    {
        protected override AbstractValidator<T> CreateValidator()
        {
            var validatorAssembly = typeof (ActivateTemplateValidator).Assembly;
            var genericValidatorType = typeof (AbstractValidator<>);
            var concreteValidatorType = genericValidatorType.MakeGenericType(typeof (T));

            var validatorType = validatorAssembly.GetTypes()
                .Where(t => concreteValidatorType.IsAssignableFrom(t))
                .Single();

            return (AbstractValidator<T>) Activator.CreateInstance(validatorType);
        }

        protected void FollowsEventSourceIdRules(
            Func<Guid, T> constructor, Expression<Func<T, Guid>> getter)
        {
            var expected = Guid.NewGuid();
            var actual = getter.Compile().Invoke(constructor(expected));
            Assert.AreEqual(expected, actual, "Getter doesn't return expected value. Are you testing the right property");

            //Event source Id isn't default(Guid)
            GetFailure(constructor(default(Guid)), getter);
        }

        protected void FollowsEquipmentNameRules(
            Func<string, T> constructor, Expression<Func<T, string>> getter)
        {
            FollowsShortStringRules(constructor, getter);
        }

        protected void FollowsShortStringRules(
            Func<string, T> constructor, Expression<Func<T, string>> getter)
        {
            FollowsStringRules(constructor, getter);
            MaxLength(255, constructor, getter);

            TestAllCharacters(
                "A{0}",
                c => !char.IsControl(c),
                constructor,
                getter);
        }

        protected void FollowsStringRules(
            Func<string, T> constructor, Expression<Func<T, string>> getter)
        {
            var expected = "abcdeflaisdulkasndvpoiajuhb";
            var actual = getter.Compile().Invoke(constructor(expected));
            Assert.AreEqual(expected, actual,
                            "Getter doesn't return expected value. Are you testing the right property?");

            //String is not null
            GetFailure(constructor(null), getter);
            //String is not empty
            GetFailure(constructor(string.Empty), getter);

        }

        protected void FollowsAbbreviationRules(
            Func<string, T> constructor, Expression<Func<T, string>> getter)
        {
            FollowsStringRules(constructor, getter);
            MaxLength(15, constructor, getter);
            TestAllCharacters(
                "A{0}A",
                "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789",
                constructor,
                getter);
        }


        protected void FollowsRubricRules(
            Func<string, T> constructor,
            Expression<Func<T, string>> getter)
        {
            FollowsStringRules(constructor, getter);
            Length(4, constructor, getter);
            TestAllCharacters(
                "A{0}AA",
                c => char.IsUpper(c),
                constructor,
                getter);
        }

        protected void MaxLength(int maxLength,
            Func<string, T> constructor, Expression<Func<T, string>> getter)
        {
            var longString = "A".PadLeft(maxLength + 1, 'A');
            GetFailure(constructor(longString), getter);
        }

        protected void MinLength(int minLength,
            Func<string, T> constructor, Expression<Func<T, string>> getter)
        {
            var longString = "A".PadLeft(minLength - 1, 'A');
            GetFailure(constructor(longString), getter);
        }

        protected void Length(int length,
            Func<string, T> constructor, Expression<Func<T, string>> getter)
        {
            MaxLength(length, constructor, getter);
            MinLength(length, constructor, getter);
        }

        protected void GreaterThan(
            int value,
            Func<int, T> constructor,
            Expression<Func<T, int>> getter)
        {
            GreaterThanOrEqualTo(value, constructor, getter);
            GetFailure(constructor(value), getter);
        }

        protected void GreaterThanOrEqualTo(
            int value,
            Func<int, T> constructor,
            Expression<Func<T, int>> getter)
        {
            if (value >= 0)
            {
                GetFailure(constructor(-1000), getter);
                GetFailure(constructor(-1), getter);
            }

            GetFailure(constructor(value - 1000), getter);
            GetFailure(constructor(value - 1), getter);
        }

        protected void TestAllCharacters(
            string pattern,
            IEnumerable<char> validCharacters,
            Func<string, T> constructor,
            Expression<Func<T, string>> getter)
        {
            var validCharactersArray = validCharacters.ToArray();
            TestAllCharacters(
                pattern,
                c => validCharactersArray.Contains(c),
                constructor,
                getter);
        }

        protected void TestAllCharacters(
            string pattern,
            Func<char, bool> validCharacters,
            Func<string, T> constructor,
            Expression<Func<T, string>> getter)
        {

            var attempts = GetCharacters()
                .Select(c => new
                                 {
                                     shouldBeValid = validCharacters(c),
                                     value = string.Format(pattern, c)
                                 })
                .Select(item => new
                                    {
                                        item.shouldBeValid,
                                        item.value,
                                        charList = string.Join(", ", item.value.Select(Convert.ToInt64)),
                                        instance = constructor(item.value)
                                    })
                .ToArray();

            var validator = CreateValidator();
            var propertyName = GetPropertyName(getter);

            var failure = attempts
                .Where(item => !IsCorrect(item.shouldBeValid, item.instance, validator, propertyName))
                .FirstOrDefault();

            if (failure == null) return;
            var safeValue = failure.value.Replace("\0", "<null>");

            Console.WriteLine("Failed value: {0} [{1}]",
                              safeValue,
                              failure.charList);
            if (failure.shouldBeValid)
                Assert.Fail("{0} {1} should have passed validation when set to {2} [{3}]",
                            typeof (T),
                            getter.ToString(),
                            safeValue,
                            failure.charList);
            if (!failure.shouldBeValid)
                Assert.Fail("{0} {1} should have failed validation when set to {2} [{3}]",
                            typeof (T),
                            getter.ToString(),
                            safeValue,
                            failure.charList);
        }

        protected bool IsCorrect(
            bool shouldBeValid,
            T instance,
            IValidator<T> validator,
            string propertyName)
        {
            return shouldBeValid
                       ? IsValid(instance, validator, propertyName)
                       : !IsValid(instance, validator, propertyName);
        }
        
        private static IEnumerable<char> GetCharacters()
        {
            for (var c = char.MinValue; c < char.MaxValue; c++)
                    yield return c;
        }
    }

}
