using System.Collections.Generic;
using ISIS.Web.Models;

namespace ISIS.Web.Areas.Schedule.Models.Instructor.ViewModels
{
    public interface IInstructorList : IJsonSerializable 
    {

        IEnumerable<InstructorListItem> Instructors { get; }

    }
}