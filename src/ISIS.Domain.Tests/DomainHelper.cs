using System;
using System.Collections.Generic;
using System.Linq;
using ISIS.Commands;
using Ncqrs;
using Ncqrs.Commanding;
using Ncqrs.Commanding.CommandExecution.Mapping.Attributes;
using Ncqrs.Commanding.ServiceModel;
using Ncqrs.Eventing;
using Ncqrs.Spec;
using TechTalk.SpecFlow;

namespace ISIS.Domain.Tests
{
    public static class DomainHelper
    {

        private class ReferenceWrapper<T>
        {
            private readonly T _value;

            public ReferenceWrapper(T value)
            {
                _value = value;
            }

            public T Value { get { return _value; } }
        }

        public static void Execute<TCommand>(TCommand command)
            where TCommand : ICommand
        {
            SetAggregateId(command);

            var cmdService = NcqrsEnvironment.Get<ICommandService>();
            using (var ctx = new EventContext())
            {
                cmdService.Execute(command);
                ScenarioContext.Current.Set(ctx.Events);
            }
        }

        private static void SetAggregateId<TCommand>(TCommand command)
        {
            var commandType = typeof (TCommand);

            var aggregateAttribute = (MapsToAggregateRootConstructorAttribute)
                commandType.GetCustomAttributes(typeof (MapsToAggregateRootConstructorAttribute), true).FirstOrDefault();


            if (aggregateAttribute != null)
            {
                var aggregateType = aggregateAttribute.Type;

                var idProperty = commandType
                    .GetProperties()
                    .Where(pi => pi.GetCustomAttributes(typeof (CreateAggregateWithIdAttribute), true).Any())
                    .Single();

                var id = (Guid) idProperty.GetValue(command, new object[0]);

                SetAggregateId(aggregateType, id);
            }
        }

        private static void SetAggregateId(Type aggregateType, Guid id)
        {
            var wrappedId = new ReferenceWrapper<Guid>(id);
            ScenarioContext.Current.Set(wrappedId, "AggregateRoot: " + aggregateType);
        }

        public static TEvent Event<TEvent>()
        {
            var events = ScenarioContext.Current
                .Get<IEnumerable<UncommittedEvent>>()
                .Select(e => e.Payload);
            return events.OfType<TEvent>().Single();
        }

        public static Guid Id<TAggregate>()
        {
            var aggregateType = typeof (TAggregate);
            var wrappedId = ScenarioContext.Current.Get<ReferenceWrapper<Guid>>("AggregateRoot: " + aggregateType);
            return wrappedId.Value;
        }
        
    }
}
