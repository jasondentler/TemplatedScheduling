using System;
using Ncqrs.Commanding;

namespace ISIS.Scheduling
{
    public class CreateTerm : CommandBase 
    {
        public Guid TermId { get; private set; }
        public string Abbreviation { get; private set; }
        public string Name { get; private set; }
        public DateTime Start { get; private set; }
        public DateTime End { get; private set; }
        public bool IsContinuingEducation { get; private set; }

        public CreateTerm(Guid termId, string abbreviation, string name, 
            DateTime start, DateTime end, bool isContinuingEducation)
        {
            TermId = termId;
            Abbreviation = abbreviation;
            Name = name;
            Start = start;
            End = end;
            IsContinuingEducation = isContinuingEducation;
        }
    }
}
