using System;
using System.Collections.Generic;

namespace ISIS.Scheduling
{

    public struct TemplateData
    {

        public Guid TemplateId;
        public Guid CourseId;
        public Guid TermId;
        public Guid InstructorId;
        public string Rubric;
        public string CourseNumber;
        public string Title;
        public string Description;
        public bool IsContinuingEducation;
        public TemplateStatuses Status;
        public string Label;
        public IDictionary<string, int> InstructorEquipment;
        public IDictionary<string, StudentEquipmentQuantity> StudentEquipment;

    }

}
