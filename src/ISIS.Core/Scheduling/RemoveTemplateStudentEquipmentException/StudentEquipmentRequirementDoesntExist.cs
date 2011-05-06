namespace ISIS.Scheduling.RemoveTemplateStudentEquipmentException
{
    public class StudentEquipmentRequirementDoesntExist : InvalidAggregateStateException
    {

        public StudentEquipmentRequirementDoesntExist()
            : base("Your attempt to remove this equipment requirement failed. The template already doesn't require this equipment.")
        {
        }

    }
}
