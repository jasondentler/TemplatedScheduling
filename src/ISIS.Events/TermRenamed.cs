using System;

namespace ISIS.Events
{
    public class TermRenamed
    {
        public Guid TermId { get; private set; }
        public string OldName { get; private set; }
        public string NewName { get; private set; }

        public TermRenamed(Guid termId, string oldName, string newName)
        {
            TermId = termId;
            OldName = oldName;
            NewName = newName;
        }
    }
}
