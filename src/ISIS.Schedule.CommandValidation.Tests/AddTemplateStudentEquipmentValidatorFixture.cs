using System;
using ISIS.Scheduling;
using Ncqrs.Spec;

namespace ISIS.Schedule
{
    public class AddTemplateStudentEquipmentValidatorFixture
        : ConventionValidationFixture<AddTemplateStudentEquipment>
    {
        protected override AddTemplateStudentEquipment GetValidInstance()
        {
            return new AddTemplateStudentEquipment(
                Guid.NewGuid(),
                15,
                "Toaster Oven",
                3);
        }

        [Then]
        public void TemplateIdFollowsRules()
        {
            FollowsEventSourceIdRules(
                id => new AddTemplateStudentEquipment(id, 15, "Toaster Oven", 3),
                cmd => cmd.TemplateId);
        }

        [Then]
        public void QuantityisGreaterThanZero()
        {
            GreaterThan(0, qty => new AddTemplateStudentEquipment(
                                      Guid.NewGuid(),
                                      qty,
                                      "Toaster Oven",
                                      3),
                        cmd => cmd.Quantity);
        }

        [Then]
        public void EquipmentNameFollowsEquipmentNameRules()
        {
            FollowsEquipmentNameRules(equipmentName => new AddTemplateStudentEquipment(
                                                           Guid.NewGuid(),
                                                           15,
                                                           equipmentName,
                                                           3),
                                      cmd => cmd.EquipmentName);
        }

        [Then]
        public void PerStudentisGreaterThanZero()
        {
            GreaterThan(0, perStudent => new AddTemplateStudentEquipment(
                                             Guid.NewGuid(),
                                             15,
                                             "Toaster Oven",
                                             perStudent),
                        cmd => cmd.PerStudent);
        }

    }
}
