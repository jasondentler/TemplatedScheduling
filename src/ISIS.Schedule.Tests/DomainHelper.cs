using System;
using System.Collections.Generic;
using System.Linq;
using Ncqrs;
using Ncqrs.Commanding;
using Ncqrs.Commanding.ServiceModel;
using Ncqrs.Eventing;
using Ncqrs.Eventing.Storage;
using Ncqrs.Spec;
using TechTalk.SpecFlow;

namespace ISIS.Schedule
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
                catch (Ncqrs.Commanding.CommandExecution.Mapping.CommandMappingException)
                {
                    throw;
                }
                catch (Exception exception)
                {
                    SetException(command, exception);
                }
            }
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

        private static IEnumerable<object> GetEvents()
        {
            return ScenarioContext.Current
                .Get<IEnumerable<UncommittedEvent>>()
                .Select(e => e.Payload);
        }

        private static HashSet<object> CheckedEvents
        {
            get { 
                const string key = "CheckedEventsKey";
                var ctx = ScenarioContext.Current;
                if (ctx.ContainsKey(key))
                    return ctx.Get<HashSet<object>>(key);
                var set = new HashSet<object>();
                ctx.Set(set, key);
                return set;
            }
        }

        public static TEvent Then<TEvent>()
        {
            var events = GetEvents();
            var @event = events.OfType<TEvent>().Single();
            DomainLogger.Then(@event);
            CheckedEvents.Add(@event);
            return @event;
        }
        
        public static Guid Id<TAggregate>()
        {
            return Id<TAggregate>(new string[0]);
        }

        public static Guid Id<TAggregate>(params string[] naturalId)
        {
            if (naturalId == null)
                naturalId = new string[0];
            var aggregateType = typeof(TAggregate);

            var elements = new string[] {aggregateType.ToString()}.Union(naturalId);
            var key = string.Join(",", elements);

            if (ScenarioContext.Current.ContainsKey(key))
                return ScenarioContext.Current.Get<ReferenceWrapper<Guid>>(key).Value;
            var id = Guid.NewGuid();
            ScenarioContext.Current.Set(new ReferenceWrapper<Guid>(id), key);
            ScenarioContext.Current.Set(new ReferenceWrapper<Guid>(id), aggregateType.ToString());
            return id;
        }

        public static bool AllEventsChecked()
        {
            return !GetEvents().Except(CheckedEvents).Any();
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

        public static IEnumerable<object> GetEventStream(Guid eventSourceId)
        {
            var store = NcqrsEnvironment.Get<IEventStore>();
            var existingEvents = store.ReadFrom(eventSourceId, 0, long.MaxValue);
            return existingEvents.Select(e => e.Payload);
        }

    }
}
