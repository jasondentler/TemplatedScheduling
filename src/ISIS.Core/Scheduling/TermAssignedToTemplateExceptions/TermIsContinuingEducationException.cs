namespace ISIS.Scheduling.TermAssignedToTemplateExceptions
{
    public class TermIsContinuingEducationException : InvalidAggregateStateException
    {

        public TermIsContinuingEducationException()
            : base("Your attempt to assign the term failed. The term is for continuing education only.")
        {
        }

    }
}
