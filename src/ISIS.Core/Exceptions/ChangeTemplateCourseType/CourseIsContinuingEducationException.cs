namespace ISIS.Exceptions.ChangeTemplateCourseType
{
    public class CourseIsContinuingEducationException : InvalidAggregateStateException
    {

        public CourseIsContinuingEducationException()
            : base("Your attempt to change the course type failed because this is a continuing education course.")
        {
        }

    }
}