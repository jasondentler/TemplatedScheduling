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

        const string CheckedEventCountKey = "CheckedEventCount";

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
            var cmdService = NcqrsEnvironment.Get<ICommandService>();
            using (var ctx = new EventContext())
            {
                cmdService.Execute(command);
                ScenarioContext.Current.Set(ctx.Events);
            }
            SetAggregateId<TCommand>();
        }

        private static void SetAggregateId<TCommand>()
        {
            var commandType = typeof (TCommand);

            var aggregateAttribute = (MapsToAggregateRootConstructorAttribute)
                                     commandType
                                         .GetCustomAttributes(typeof (MapsToAggregateRootConstructorAttribute), true)
                                         .FirstOrDefault();

            if (aggregateAttribute == null) return;

            var aggregateType = aggregateAttribute.Type;

            var id = (Guid) ScenarioContext.Current
                                .Get<IEnumerable<UncommittedEvent>>()
                                .First()
                                .EventSourceId;

            SetAggregateId(aggregateType, id);
        }

        private static void SetAggregateId(Type aggregateType, Guid id)
        {
            var wrappedId = new ReferenceWrapper<Guid>(id);
            ScenarioContext.Current.Set(wrappedId, "AggregateRoot: " + aggregateType);
        }

        private static IEnumerable<object> GetEvents()
        {
            return ScenarioContext.Current
                .Get<IEnumerable<UncommittedEvent>>()
                .Select(e => e.Payload);
        }

        public static TEvent Event<TEvent>()
        {
            var events = GetEvents();
            CheckedEventCount++;
            return events.OfType<TEvent>().Single();
        }

        private static int CheckedEventCount
        {
            get
            {
                var ctx = ScenarioContext.Current;

                return ctx.ContainsKey(CheckedEventCountKey)
                           ? ctx.Get<ReferenceWrapper<int>>(CheckedEventCountKey).Value
                           : 0;
            }
            set
            {
                ScenarioContext.Current.Set(new ReferenceWrapper<int>(value),
                                                                   CheckedEventCountKey);
            }
        }

        public static Guid Id<TAggregate>()
        {
            var aggregateType = typeof (TAggregate);
            var wrappedId = ScenarioContext.Current.Get<ReferenceWrapper<Guid>>("AggregateRoot: " + aggregateType);
            return wrappedId.Value;
        }

        public static bool AllEventsChecked()
        {
            return GetEvents().Count() == CheckedEventCount;
        }

    }
}
