using Ncqrs.Commanding.CommandExecution;
using Ncqrs.Commanding.CommandExecution.Mapping.Fluent;
using Ncqrs.Commanding.ServiceModel;

namespace ISIS.Scheduling
{

    public class RoomMapping : IMapping
    {
        private readonly CommandService _commandService;

        public RoomMapping(CommandService commandService)
        {
            _commandService = commandService;
        }

        public void Register()
        {
            Map.Command<CreateRoom>()
                .ToAggregateRoot<Room>()
                .CreateNew(cmd => new Room(cmd.RoomId, cmd.RoomNumber))
                .RegisterWith(_commandService);

            Map.Command<AddEquipmentToRoom>()
                .ToAggregateRoot<Room>()
                .WithId(cmd => cmd.RoomId)
                .ToCallOn((cmd, room) => room.AddEquipment(cmd.Quantity, cmd.EquipmentName))
                .RegisterWith(_commandService);

            Map.Command<RemoveEquipmentFromRoom>()
                .ToAggregateRoot<Room>()
                .WithId(cmd => cmd.RoomId)
                .ToCallOn((cmd, room) => room.RemoveEquipment(cmd.Quantity, cmd.EquipmentName))
                .RegisterWith(_commandService);
        }
    }


}
