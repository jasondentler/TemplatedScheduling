using System;
using ISIS.Events;
using Ncqrs.Domain;

namespace ISIS.Domain
{
    public class Course : AggregateRootMappedByConvention
    {

        private string _rubric;
        private string _courseNumber;
        private string _title;
        private string _shortTitle;
        private string _cip;
        private string _description;

        private Course()
        {
        }
        
        public Course(Guid courseId, string rubric, string courseNumber)
            : base(courseId)
        {
            ApplyEvent(new CourseCreated(EventSourceId, rubric, courseNumber));
        }


        public void ChangeTitle(string newTitle, string newShortTitle)
        {
            if (_title != newTitle || _shortTitle != newShortTitle)
                ApplyEvent(new CourseRenamed(
                               EventSourceId,
                               _title,
                               newTitle,
                               _shortTitle,
                               newShortTitle));
        }

        public void ChangeCIP(string cip)
        {
            if (_cip != cip)
                ApplyEvent(new CourseCIPChanged(
                               EventSourceId,
                               _cip,
                               cip));
        }

        public void ChangeDescription(string description)
        {
            if (_description != description)
                ApplyEvent(new CourseDescriptionChanged(
                               EventSourceId,
                               _description,
                               description));
        }

        internal CourseData GetCourseData()
        {
            return new CourseData()
                       {
                           CourseId = EventSourceId,
                           Rubric = _rubric,
                           CourseNumber = _courseNumber,
                           Title = _title,
                           CIP = _cip,
                           Description = _description
                       };
        }


        protected void On(CourseCreated @event)
        {
            _rubric = @event.Rubric;
            _courseNumber = @event.CourseNumber;
        }

        protected void On(CourseRenamed @event)
        {
            _title = @event.NewTitle;
            _shortTitle = @event.NewShortTitle;
        }

        protected void On(CourseCIPChanged @event)
        {
            _cip = @event.NewCIP;
        }

        protected void On(CourseDescriptionChanged @event)
        {
            _description = @event.NewDescription;
        }

    }
}
