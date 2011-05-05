namespace ISIS.Scheduling.AssignInstructorToSectionExceptions
{
    public class InstructorNotAssignedCourse : InvalidAggregateStateException
    {

        public InstructorNotAssignedCourse()
            : base("Your attempt to assign an instructor to this section failed. This instructor isn't assigned this course.")
        {
        }

    }
}
