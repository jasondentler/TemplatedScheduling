using System;
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
            //String is not whitespace
            GetFailure(constructor(" \t \r \n "), getter);
        }

        protected void FollowsAbbreviationRules(
            Func<string, T> constructor, Expression<Func<T, string>> getter)
        {
            FollowsStringRules(constructor, getter);
            MaxLength(15, constructor, getter);
            NoWhiteSpace(constructor, getter);
        }

        protected void MaxLength(int maxLength,
            Func<string, T> constructor, Expression<Func<T, string>> getter)
        {
            var longString = "A".PadLeft(maxLength + 1, 'A');
            GetFailure(constructor(longString), getter);
        }

        protected void NoWhiteSpace(
            Func<string, T> constructor, Expression<Func<T, string>> getter)
        {
            GetFailure(constructor("A A"), getter);
            GetFailure(constructor("A\tA"), getter);
            GetFailure(constructor("A\rA"), getter);
            GetFailure(constructor("A\nA"), getter);
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

    }

}
