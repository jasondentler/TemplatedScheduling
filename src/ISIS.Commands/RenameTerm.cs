using System;
using Ncqrs.Commanding;

namespace ISIS.Commands
{

    public class RenameTerm : CommandBase 
    {
        public Guid TermId { get; private set; }
        public string NewName { get; private set; }

        public RenameTerm(Guid termId, string newName)
        {
            TermId = termId;
            NewName = newName;
        }
    }

}
