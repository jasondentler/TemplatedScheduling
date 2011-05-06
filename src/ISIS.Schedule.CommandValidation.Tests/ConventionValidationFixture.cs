using System;
using System.Linq;
using FluentValidation;

namespace ISIS.Schedule
{

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

    }

}
