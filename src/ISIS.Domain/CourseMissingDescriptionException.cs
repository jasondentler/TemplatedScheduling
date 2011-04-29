namespace ISIS.Domain
{
    public class CourseMissingDescriptionException : InvalidAggregateStateException
    {

        public CourseMissingDescriptionException()
            : base("Your attempt to activate the course failed because the course is missing a description.")
        {
        }

    }
}
