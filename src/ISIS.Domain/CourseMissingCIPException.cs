namespace ISIS.Domain
{
    public class CourseMissingCIPException : InvalidAggregateStateException
    {

        public CourseMissingCIPException()
            : base("Your attempt to activate the course failed because the course is missing a CIP.")
        {
        }

    }
}
