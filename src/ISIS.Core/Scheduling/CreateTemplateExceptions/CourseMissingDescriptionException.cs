namespace ISIS.Scheduling.CreateTemplateExceptions
{
    public class CourseMissingDescriptionException : InvalidAggregateStateException
    {

        public CourseMissingDescriptionException()
            : base("Your attempt to create a template failed because the course is missing a description.")
        {
        }

    }
}
