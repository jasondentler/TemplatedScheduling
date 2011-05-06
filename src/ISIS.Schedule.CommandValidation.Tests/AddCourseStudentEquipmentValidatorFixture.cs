using System;
using ISIS.Scheduling;
using Ncqrs.Spec;

namespace ISIS.Schedule
{
    public class AddCourseStudentEquipmentValidatorFixture
        : ConventionValidationFixture<AddCourseStudentEquipment>
    {
        protected override AddCourseStudentEquipment GetValidInstance()
        {
            return new AddCourseStudentEquipment(
                Guid.NewGuid(),
                15,
                "Toaster Oven",
                2);
        }

        [Then]
        public void CourseIdFollowsRules()
        {
            FollowsEventSourceIdRules(
                id => new AddCourseStudentEquipment(id, 15, "Toaster Oven", 2),
                cmd => cmd.CourseId);
        }

        [Then]
        public void QuantityisGreaterThanZero()
        {
            GreaterThan(0, qty => new AddCourseStudentEquipment(
                                      Guid.NewGuid(),
                                      qty,
                                      "Toaster Oven",
                                      2),
                        cmd => cmd.Quantity);
        }

        [Then]
        public void EquipmentNameFollowsEquipmentNameRules()
        {
            FollowsEquipmentNameRules(equipmentName => new AddCourseStudentEquipment(
                                                           Guid.NewGuid(),
                                                           15,
                                                           equipmentName,
                                                           2),
                                      cmd => cmd.EquipmentName);
        }

        [Then]
        public void PerStudentIsGreaterThanZero()
        {
            GreaterThan(0, perStudent => new AddCourseStudentEquipment(
                                             Guid.NewGuid(),
                                             15,
                                             "Toaster Oven",
                                             perStudent),
                        cmd => cmd.PerStudent);
        }

    }
}
