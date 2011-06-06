using System;
using System.Collections.Generic;
using ISIS.Web.Models;

namespace ISIS.Web.Areas.Schedule.Models.Section.ViewModels
{
    public class ChangeTerm : JsonSerializable 
    {
        public Guid Id { get; private set; }
        public IDictionary<Guid, string> AvailableTerms { get; private set; }

        public ChangeTerm(
            Guid id,
            IDictionary<Guid, string> availableTerms) 
        {
            Id = id;
            AvailableTerms = availableTerms;
        }
    }
}
