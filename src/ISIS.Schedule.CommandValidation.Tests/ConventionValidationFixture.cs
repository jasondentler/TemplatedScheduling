using System;
using System.Linq;
using System.Linq.Expressions;
using FluentValidation;
using Ncqrs.Spec;

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
            //Event source Id isn't default(Guid)
            GetFailure(constructor(default(Guid)), getter);
        }

        protected void FollowsEquipmentNameRules(
            Func<string, T> constructor, Expression<Func<T, string>> getter)
        {
            //Equipment name is not null
            GetFailure(constructor(null), getter);
            GetFailure(constructor(string.Empty), getter);
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
