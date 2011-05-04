namespace ISIS.Scheduling.TermAssignedToTemplateExceptions
{
    public class TermIsNotContinuingEducationException : InvalidAggregateStateException
    {

        public TermIsNotContinuingEducationException()
            : base("Your attempt to assign the term failed. The term is not for continuing education.")
        {
        }

    }
}
