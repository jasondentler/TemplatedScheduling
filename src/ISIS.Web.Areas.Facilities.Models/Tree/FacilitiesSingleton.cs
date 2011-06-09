using System;
using System.Collections.Generic;
using System.Linq;

namespace ISIS.Web.Areas.Facilities.Models.Tree
{
    public class FacilitiesSingleton
    {

        public static readonly FacilitiesSingleton Facilities;

        static FacilitiesSingleton()
        {
            Facilities = new FacilitiesSingleton();
        }

        private FacilitiesSingleton()
        {
            _rows = new HashSet<Tuple<Guid, Guid, string>>();

            AddRow("Main Campus",
                   cid =>
                       {
                           AddRow(cid, "A",
                                  bid =>
                                  {
                                      AddRow(bid, "1st Floor");
                                      AddRow(bid, "2nd Floor");
                                  });
                           AddRow(cid, "B",
                                  bid =>
                                  {
                                      AddRow(bid, "1st Floor");
                                      AddRow(bid, "2nd Floor");
                                  });
                           AddRow(cid, "C",
                                  bid =>
                                  {
                                      AddRow(bid, "1st Floor");
                                      AddRow(bid, "2nd Floor");
                                  });
                           AddRow(cid, "D",
                                  bid =>
                                  {
                                      AddRow(bid, "1st Floor");
                                      AddRow(bid, "2nd Floor");
                                  });
                           AddRow(cid, "E",
                                  bid => AddRow(bid, "1st Floor"));
                           AddRow(cid, "F",
                                  bid =>
                                  {
                                      AddRow(bid, "1st Floor");
                                      AddRow(bid, "2nd Floor");
                                  });
                           AddRow(cid, "G",
                                  bid => AddRow(bid, "1st Floor", 
                                                mid =>
                                                    {
                                                        AddRow(mid, "G100");
                                                        AddRow(mid, "G105");
                                                        AddRow(mid, "G111");
                                                        AddRow(mid, "G112");
                                                        AddRow(mid, "G126");
                                                    }));
                           AddRow(cid, "H",
                                  bid => AddRow(bid, "1st Floor"));
                           AddRow(cid, "J",
                                  bid => AddRow(bid, "1st Floor"));
                           AddRow(cid, "K",
                                  bid => AddRow(bid, "1st Floor"));
                           AddRow(cid, "N",
                                  bid => AddRow(bid, "1st Floor"));
                           AddRow(cid, "Nolan Ryan Center",
                                  bid => AddRow(bid, "1st Floor"));
                           AddRow(cid, "S",
                                  bid =>
                                      {
                                          AddRow(bid, "1st Floor");
                                          AddRow(bid, "2nd Floor");
                                      });
                       });
            AddRow("Pearland Campus",
                   cid =>
                       {

                       });
        }

        public IEnumerable<Tuple<Guid, string, bool>> GetChildren(Guid parentId)
        {
            return _rows
                .Where(i => i.Item2 == parentId)
                .Select(i => new Tuple<Guid, string, bool>(
                                 i.Item1,
                                 i.Item3,
                                 _rows.Any(row => row.Item2 == i.Item1)));
        }


        private readonly ISet<Tuple<Guid, Guid, string>> _rows;

        private Guid AddRow(string text, Action<Guid> createChildren)
        {
            var id = AddRow(Guid.Empty, text);
            createChildren(id);
            return id;
        }

        private Guid AddRow(Guid parentId, string text)
        {
            var id = Guid.NewGuid();
            _rows.Add(new Tuple<Guid, Guid, string>(
                          id, parentId, text));
            return id;
        }

        private Guid AddRow(Guid parentId, string text, Action<Guid> createChildren)
        {
            var id = AddRow(parentId, text);
            createChildren(id);
            return id;
        }

    }
}
