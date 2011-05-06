namespace ISIS.Scheduling.RemoveCourseStudentEquipmentException
{
    public class StudentEquipmentRequirementDoesntExist : InvalidAggregateStateException
    {

        public StudentEquipmentRequirementDoesntExist()
            : base("Your attempt to remove this equipment requirement failed. The course already doesn't require this equipment.")
        {
        }

    }
}
