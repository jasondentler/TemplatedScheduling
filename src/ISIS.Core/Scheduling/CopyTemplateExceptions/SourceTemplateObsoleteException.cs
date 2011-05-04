namespace ISIS.Scheduling.CopyTemplateExceptions
{
    public class SourceTemplateObsoleteException : InvalidAggregateStateException
    {

        public SourceTemplateObsoleteException()
            : base("Your attempt to copy the template failed. The source template is obsolete.")
        {
        }

    }
}
