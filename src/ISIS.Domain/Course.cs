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
        private bool _isContinuingEducation;

        private Course()
        {
        }
        
        public Course(Guid courseId, string rubric, string courseNumber)
            : base(courseId)
        {
            ApplyEvent(new CourseCreated(EventSourceId, rubric, courseNumber, IsContinuingEducation(courseNumber)));
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
                           Description = _description,
                           IsContinuingEducation = _isContinuingEducation
                       };
        }


        protected void On(CourseCreated @event)
        {
            _rubric = @event.Rubric;
            _courseNumber = @event.CourseNumber;
            _isContinuingEducation = @event.IsContinuingEducation;
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

        private static int GetCreditHours(string courseNumber)
        {
            return int.Parse(courseNumber.Substring(1, 1));
        }

        private static bool IsContinuingEducation(string courseNumber)
        {
            return GetCreditHours(courseNumber) == 0;
        }

    }
}
