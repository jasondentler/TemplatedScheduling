using System;

namespace ISIS.Exceptions
{
    public class InvalidAggregateStateException : ApplicationException
    {

        public InvalidAggregateStateException(string message)
            :base(message)
        {
        }

    }
}