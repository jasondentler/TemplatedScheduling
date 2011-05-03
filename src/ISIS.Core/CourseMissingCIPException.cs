namespace ISIS
{
    public class CourseMissingCIPException : InvalidAggregateStateException
    {

        public CourseMissingCIPException()
            : base("Your attempt to create a template failed because the course is missing a CIP.")
        {
        }

    }
}
