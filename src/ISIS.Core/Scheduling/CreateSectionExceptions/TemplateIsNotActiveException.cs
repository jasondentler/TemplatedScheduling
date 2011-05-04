namespace ISIS.Scheduling.CreateSectionExceptions
{
    public class TemplateIsNotActiveException : InvalidAggregateStateException
    {

        public TemplateIsNotActiveException()
            : base("Your attempt to create a section failed. The template is not active.")
        {
        }

    }
}
