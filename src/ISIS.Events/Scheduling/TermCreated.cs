using System;

namespace ISIS.Scheduling
{
    public class TermCreated
    {

        public Guid TermId { get; private set; }
        public string Abbreviation { get; private set; }
        public string Name { get; private set; }
        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set; }
        public bool IsContinuingEducation { get; private set; }

        public TermCreated(
            Guid termId,
            string abbreviation,
            string name,
            DateTime startDate,
            DateTime endDate,
            bool isContinuingEducation)
        {
            TermId = termId;
            Abbreviation = abbreviation;
            Name = name;
            StartDate = startDate;
            EndDate = endDate;
            IsContinuingEducation = isContinuingEducation;
        }
    }
}
