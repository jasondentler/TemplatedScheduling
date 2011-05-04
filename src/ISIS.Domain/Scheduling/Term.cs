using System;
using Ncqrs.Domain;

namespace ISIS.Scheduling
{

    public class Term : AggregateRootMappedByConvention
    {

        private string _name;
        private DateTime _startDate;
        private DateTime _endDate;
        private bool _isContinuingEducation;

        private Term()
        {
        }

        public Term(Guid termId, string abbreviation, string name, DateTime start, DateTime end, bool isContinuingEducation)
        {
            ApplyEvent(new TermCreated(termId, abbreviation, name, start, end, isContinuingEducation));
        }

        public void Rename(string newName)
        {
            if (_name != newName)
                ApplyEvent(new TermRenamed(EventSourceId, _name, newName));
        }

        internal TermData GetTermData()
        {
            return new TermData()
                       {
                           TermId = EventSourceId,
                           Name = _name,
                           StartDate = _startDate,
                           EndDate = _endDate,
                           IsContinuingEducation = _isContinuingEducation
                       };
        }

        protected void On(TermCreated @event)
        {
            _name = @event.Name;
            _startDate = @event.StartDate;
            _endDate = @event.EndDate;
            _isContinuingEducation = @event.IsContinuingEducation;
        }

        protected void On(TermRenamed @event)
        {
            _name = @event.NewName;
        }


    }

}
