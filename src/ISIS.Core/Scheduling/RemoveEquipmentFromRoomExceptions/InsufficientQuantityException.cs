namespace ISIS.Scheduling.RemoveEquipmentFromRoomExceptions
{
    public class InsufficientQuantityException : InvalidAggregateStateException
    {

        public InsufficientQuantityException(int quantity, string equipmentName)
            : base(string.Format("Your attempt to equipment failed. This room doesn't have {0} {1}.", quantity, equipmentName))
        {
        }

    }
}
