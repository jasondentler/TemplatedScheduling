using System;
using Ncqrs.Domain;

namespace ISIS.Scheduling
{

    public class Term : AggregateRootMappedByConvention
    {

        private string _name;

        private Term()
        {
        }

        public Term(Guid termId, string abbreviation, string name, DateTime start, DateTime end)
        {
            ApplyEvent(new TermCreated(termId, abbreviation, name, start, end));
        }

        public void Rename(string newName)
        {
            if (_name != newName)
                ApplyEvent(new TermRenamed(EventSourceId, _name, newName));
        }

        protected void On(TermCreated @event)
        {
            _name = @event.Name;
        }

        protected void On(TermRenamed @event)
        {
            _name = @event.NewName;
        }

    }

}
