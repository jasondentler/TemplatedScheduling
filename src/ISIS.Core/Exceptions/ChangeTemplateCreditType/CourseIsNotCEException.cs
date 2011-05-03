namespace ISIS.Exceptions.ChangeTemplateCreditType
{
    public class CourseIsNotCEException : InvalidAggregateStateException
    {

        public CourseIsNotCEException()
            : base("Your attempt to change the credit type failed because this is not a continuing education course.")
        {
        }

    }
}