using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace ISIS.Domain.Tests
{
    public static class DomainLogger
    {

        public static void Given(object @event)
        {
            OutputObject("Given", @event);
        }

        public static void When(object command, IEnumerable<object> events)
        {
            OutputObject("When", command);
            foreach (var @event in events)
                OutputObject("\tResult", @event);
        }

        public static void When(object command, Exception exception)
        {
            OutputObject("When", command);
            OutputException("\tResult", exception);
        }

        public static void Then(object @event)
        {
            OutputObject("Then", @event);
        }

        private static void OutputObject(string prefix, object obj)
        {
            var json = JsonConvert.SerializeObject(obj);
            Console.WriteLine("\t{0} {1}: {2}",
                              prefix,
                              obj.GetType(),
                              json);
        }

        private static void OutputException(string prefix, Exception exception)
        {
            Console.WriteLine("\t{0} {1}",
                              prefix, exception);
        }

    }
}
