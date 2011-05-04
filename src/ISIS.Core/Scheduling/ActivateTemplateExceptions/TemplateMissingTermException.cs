namespace ISIS.Scheduling.ActivateTemplateExceptions
{
    public class TemplateMissingTermException : InvalidAggregateStateException
    {

        public TemplateMissingTermException()
            : base("Your attempt to activate the template failed. The template is missing a term.")
        {
        }

    }
}
