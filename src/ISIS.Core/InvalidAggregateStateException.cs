using System;

namespace ISIS
{
    public class InvalidAggregateStateException : ApplicationException
    {

        public InvalidAggregateStateException(string message)
            :base(message)
        {
        }

    }
}