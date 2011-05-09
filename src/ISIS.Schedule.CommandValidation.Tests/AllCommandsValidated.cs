using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentValidation;
using ISIS.Scheduling;
using Ncqrs.Commanding;
using Ncqrs.Spec;
using NUnit.Framework;

namespace ISIS.Schedule
{
    [Specification]
    public class AllCommandsValidated
    {

        [Then]
        public void AllCommandsAreValidated()
        {
            var unvalidatedCommands = GetUnvalidatedCommands().ToArray();
            var unvalidatedCommandList = unvalidatedCommands
                .Select(t => t.ToString());
            var message = string.Format(
                "The following commands are not validated:\r\n\t{0}",
                string.Join("\r\n\t", unvalidatedCommandList));
            Assert.IsEmpty(unvalidatedCommands, message);
        }
        
        private IEnumerable<Type> GetCommands()
        {
            var commandAssembly = typeof (ActivateTemplate).Assembly;
            return commandAssembly
                .GetTypes()
                .Where(t => typeof (ICommand).IsAssignableFrom(t));
        }

        private IEnumerable<Type> GetValidators()
        {
            var validatorAssembly = typeof (ActivateTemplateValidator).Assembly;
            return validatorAssembly
                .GetTypes()
                .Where(t => typeof (IValidator).IsAssignableFrom(t));
        }

        private IEnumerable<Type> GetValidatedCommands()
        {
            return GetValidators()
                .SelectMany(
                    t => t.GetInterfaces())
                .Where(i => i.IsGenericType)
                .Where(i => i.GetGenericTypeDefinition() == typeof (IValidator<>))
                .Select(i => i.GetGenericArguments().Single());
        }


        private IEnumerable<Type> GetUnvalidatedCommands()
        {
            return GetCommands().Except(GetValidatedCommands());
        }

    }
}
