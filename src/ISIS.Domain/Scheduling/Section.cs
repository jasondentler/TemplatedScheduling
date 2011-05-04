using System;
using ISIS.Scheduling.CreateSectionExceptions;
using Ncqrs.Domain;

namespace ISIS.Scheduling
{
    public class Section : AggregateRootMappedByConvention 
    {
        private Section()
        {
        }

        public Section(Guid sectionId, Template template, string sectionNumber)
            : base(sectionId)
        {
            var templateData = template.GetTemplateData();

            if (templateData.Status != TemplateStatuses.Activated)
                throw new TemplateIsNotActiveException();

            var @event = new SectionCreated(
                EventSourceId,
                templateData.TemplateId,
                templateData.CourseId,
                templateData.Rubric,
                templateData.CourseNumber,
                sectionNumber,
                templateData.Title,
                templateData.Description);
            ApplyEvent(@event);
        }

        protected void On(SectionCreated @event)
        {
        }

    }
}
