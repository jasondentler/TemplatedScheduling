namespace ISIS.Exceptions.ChangeTemplateCourseType
{
    public class ReservedCourseTypeException : InvalidAggregateStateException
    {

        public ReservedCourseTypeException()
            : base("Your attempt to change the course type failed. This course type is reserved for continuing education courses only.")
        {
        }

    }
}