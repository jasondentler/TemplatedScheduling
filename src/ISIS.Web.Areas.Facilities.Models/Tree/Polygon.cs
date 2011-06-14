using System.Collections.Generic;
using System.Linq;
using ISIS.Web.Models;

namespace ISIS.Web.Areas.Facilities.Models.Tree
{
    public class Polygon : JsonSerializable 
    {

        private readonly IList<int[]> _points;

        public IEnumerable<int[]> Points { get { return _points.ToArray(); } }

        public Polygon()
        {
            _points = new List<int[]>();
        }

        public Polygon(IEnumerable<int[]> points)
        {
            _points = new List<int[]>(points);
        }

    }
}
