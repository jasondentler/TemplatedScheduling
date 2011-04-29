using System;
using System.Collections.Generic;
using System.Linq;
using Ncqrs;
using Ncqrs.Commanding;
using Ncqrs.Commanding.CommandExecution.Mapping.Attributes;
using Ncqrs.Commanding.ServiceModel;
using Ncqrs.Eventing;
using Ncqrs.Eventing.Storage;
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

        public static void Given<TAggregate>(object @event)
        {
            Given<TAggregate>(Id<TAggregate>(), @event);
        }

        public static void Given<TAggregate>(Guid id, object @event)
        {
            var store = NcqrsEnvironment.Get<IEventStore>();
            var existingEvents = store.ReadFrom(id, 0, long.MaxValue);
            long maxEventSequence = 0;
            if (existingEvents.Any())
                maxEventSequence = existingEvents.Max(e => e.EventSequence);

            var stream = Prepare.Events(@event)
                .ForSourceUncomitted(id, Guid.NewGuid(), (int) maxEventSequence + 1);

            store.Store(stream);

            DomainLogger.Given(@event);
        }

        public static void When<TCommand>(TCommand command)
            where TCommand : ICommand
        {
            var cmdService = NcqrsEnvironment.Get<ICommandService>();
            using (var ctx = new EventContext())
            {
                try
                {
                    cmdService.Execute(command);
                    var events = ctx.Events;
                    ScenarioContext.Current.Set(events);
                    DomainLogger.When(command, events.Select(e => e.Payload));
                } 
                catch(Exception exception)
                {
                    SetException(command, exception);
                }
            }
            SetAggregateId<TCommand>();
        }

        private static void SetException<TCommand>(TCommand command, Exception exception)
        {
            if (exception is System.Reflection.TargetInvocationException)
            {
                SetException(command, exception.InnerException);
                return;
            }
            ScenarioContext.Current.Set(exception);
            DomainLogger.When(command, exception);
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

        public static TEvent Then<TEvent>()
        {
            var events = GetEvents();
            CheckedEventCount++;
            var @event = events.OfType<TEvent>().Single();
            DomainLogger.Then(@event);
            return @event;
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
            var key = "AggregateRoot: " + aggregateType;
            if (ScenarioContext.Current.ContainsKey(key))
                return ScenarioContext.Current.Get<ReferenceWrapper<Guid>>(key).Value;
            var id = Guid.NewGuid();
            ScenarioContext.Current.Set(new ReferenceWrapper<Guid>(id), key);
            return id;
        }

        public static bool AllEventsChecked()
        {
            return GetEvents().Count() == CheckedEventCount;
        }

        public static bool NoEvents()
        {
            return !GetEvents().Any();
        }
        
        public static bool ExceptionThrown()
        {
            return ScenarioContext.Current.ContainsKey(typeof (Exception).ToString());
        }

        public static Exception GetException()
        {
            return ScenarioContext.Current.Get<Exception>();
        }

    }
}
