using System;
using System.Collections.Generic;
using ISIS.Web.Models;

namespace ISIS.Web.Areas.Schedule.Models.Section.ViewModels
{
    public class ChangeInstructor : JsonSerializable 
    {
        public Guid Id { get; private set; }
        public IDictionary<Guid, string> QualifiedInstructors { get; private set; }

        public ChangeInstructor(
            Guid id,
            IDictionary<Guid, string> qualifiedInstructors) 
        {
            Id = id;
            QualifiedInstructors = qualifiedInstructors;
        }
    }
}
