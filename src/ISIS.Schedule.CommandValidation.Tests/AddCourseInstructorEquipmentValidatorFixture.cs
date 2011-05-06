using System;
using ISIS.Scheduling;
using Ncqrs.Spec;

namespace ISIS.Schedule
{
    public class AddCourseInstructorEquipmentValidatorFixture
        : ConventionValidationFixture<AddCourseInstructorEquipment>
    {
        protected override AddCourseInstructorEquipment GetValidInstance()
        {
            return new AddCourseInstructorEquipment(
                Guid.NewGuid(),
                15,
                "Toaster Oven");
        }

        [Then]
        public void CourseIdFollowsRules()
        {
            FollowsEventSourceIdRules(
                id => new AddCourseInstructorEquipment(id, 15, "Toaster Oven"),
                cmd => cmd.CourseId);
        }

        [Then]
        public void QuantityisGreaterThanZero()
        {
            GreaterThan(0, qty => new AddCourseInstructorEquipment(
                                      Guid.NewGuid(),
                                      qty,
                                      "Toaster Oven"),
                        cmd => cmd.Quantity);
        }

        [Then]
        public void EquipmentNameFollowsEquipmentNameRules()
        {
            FollowsEquipmentNameRules(equipmentName => new AddCourseInstructorEquipment(
                                                           Guid.NewGuid(),
                                                           15,
                                                           equipmentName),
                                      cmd => cmd.EquipmentName);
        }

    }
}
