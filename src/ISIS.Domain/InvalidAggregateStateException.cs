using System;

namespace ISIS.Domain
{
    public class InvalidAggregateStateException : ApplicationException
    {

        public InvalidAggregateStateException(string message)
            :base(message)
        {
        }

    }
}