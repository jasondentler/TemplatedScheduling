using System;
using System.Collections.Generic;

namespace ISIS.Scheduling
{

    public struct CourseData
    {

        public Guid CourseId;
        public string Rubric;
        public string CourseNumber;
        public string Title;
        public string Description;
        public bool IsContinuingEducation;
        public IDictionary<string, int> InstructorEquipment;
        public IDictionary<string, StudentEquipmentQuantity> StudentEquipment;

    }

}
