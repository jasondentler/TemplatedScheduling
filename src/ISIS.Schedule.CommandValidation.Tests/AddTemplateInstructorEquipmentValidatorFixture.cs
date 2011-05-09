using System;
using ISIS.Scheduling;
using Ncqrs.Spec;

namespace ISIS.Schedule
{
    public class AddTemplateInstructorEquipmentValidatorFixture
        : ConventionValidationFixture<AddTemplateInstructorEquipment>
    {
        protected override AddTemplateInstructorEquipment GetValidInstance()
        {
            return new AddTemplateInstructorEquipment(
                Guid.NewGuid(),
                15,
                "Toaster Oven");
        }

        [Then]
        public void TemplateIdFollowsRules()
        {
            FollowsEventSourceIdRules(
                id => new AddTemplateInstructorEquipment(id, 15, "Toaster Oven"),
                cmd => cmd.TemplateId);
        }

        [Then]
        public void QuantityisGreaterThanZero()
        {
            GreaterThan(0, qty => new AddTemplateInstructorEquipment(
                                      Guid.NewGuid(),
                                      qty,
                                      "Toaster Oven"),
                        cmd => cmd.Quantity);
        }

        [Then]
        public void EquipmentNameFollowsEquipmentNameRules()
        {
            FollowsEquipmentNameRules(equipmentName => new AddTemplateInstructorEquipment(
                                                           Guid.NewGuid(),
                                                           15,
                                                           equipmentName),
                                      cmd => cmd.EquipmentName);
        }

    }
}
