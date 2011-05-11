using System;
using System.Linq;
using System.Linq.Expressions;
using FluentValidation;
using FluentValidation.Results;
using NUnit.Framework;

namespace ISIS.Schedule
{

    public abstract class ValidationFixture<T>
    {

        protected abstract AbstractValidator<T> CreateValidator();
        protected abstract T GetValidInstance();

        private static ValidationFailure GetFailure(ValidationResult result, string propertyName)
        {
            return result.Errors
                .Where(vf => vf.PropertyName == propertyName)
                .FirstOrDefault();
        }

        protected ValidationResult GetResult(T instance)
        {
            return GetResult(instance, CreateValidator());
        }

        protected ValidationResult GetResult(T instance, IValidator<T> validator)
        {
            return validator.Validate(instance);
        }

        protected ValidationFailure GetFailure<TProperty>(T instance,
            Expression<Func<T, TProperty>> expression)
        {
            var expressionBody = expression.Body as MemberExpression;
            return GetFailure(instance, expressionBody.Member.Name);
        }

        protected ValidationFailure GetFailure(T instance, string propertyName)
        {
            var result = GetResult(instance);
            return GetFailure(result, propertyName);
        }
        
        protected bool IsValid(T instance,
            IValidator<T> validator,
            string propertyName)
        {
            var result = GetResult(instance, validator);
            return !result.Errors
                        .Any(vf => vf.PropertyName == propertyName);
        }

        protected string GetPropertyName<TProperty>(
            Expression<Func<T, TProperty>> property)
        {
            var expressionBody = property.Body as MemberExpression;
            return expressionBody.Member.Name;
        }

        protected void AssertIsValid(T instance)
        {
            var result = GetResult(instance);
            var errors = string.Join(
                "\r\n",
                result.Errors
                    .Select(
                        vf => string.Format("{0}: {1}", vf.PropertyName, vf.ErrorMessage))
                    .ToArray());
            Assert.That(result.IsValid, Is.True, errors);
        }

        [Test]
        public void Valid_instance_works()
        {
            AssertIsValid(GetValidInstance());
        }

    }

}
