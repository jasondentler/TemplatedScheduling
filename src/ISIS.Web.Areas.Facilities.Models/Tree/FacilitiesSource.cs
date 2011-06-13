using System;
using System.Collections.Generic;
using System.Linq;

namespace ISIS.Web.Areas.Facilities.Models.Tree
{

    public class FacilitiesSource
    {

        private enum Level
        {
            Campus = 0,
            Building = 1,
            Map = 2,
            Room = 3
        }

        private static FacilitiesSingleton Data { get { return FacilitiesSingleton.Facilities; } }

        public static IMapList GetTree(
            Guid selectedId, 
            UrlProvider roomUrlProvider,
            UrlProvider mapUrlProvider,
            UrlProvider buildingUrlProvider,
            UrlProvider campusUrlProvider)
        {
            var parentIds = new Stack<Guid>();
            FindParentIds(parentIds, selectedId);

            var tuples = parentIds
                .Select(id => Data.GetChildren(id));

            var levels = new Dictionary<Level, IEnumerable<Tuple<Guid, string, bool>>>();
            var currentLevel = Level.Campus;

            foreach (var tuplesForLevel in tuples)
            {
                levels.Add(currentLevel, tuplesForLevel);
                currentLevel += 1;
            }

            var emptyTuples = new Tuple<Guid, string, bool>[0];

            var roomTuples = levels.ContainsKey(Level.Room) ? levels[Level.Room] : emptyTuples;
            var mapTuples = levels.ContainsKey(Level.Map) ? levels[Level.Map] : emptyTuples;
            var buildingTuples = levels.ContainsKey(Level.Building) ? levels[Level.Building] : emptyTuples;
            var campusTuples = levels.ContainsKey(Level.Campus) ? levels[Level.Campus] : emptyTuples;

            var rooms = roomTuples
                .Select(i => new Room(i.Item1, i.Item2, roomUrlProvider.GetDetailsUrl(i.Item1)))
                .ToArray();

            var maps = mapTuples
                .Select(i => parentIds.Contains(i.Item1)
                                 ? new Map(i.Item1, i.Item2, mapUrlProvider.GetDetailsUrl(i.Item1), rooms)
                                 : new Map(i.Item1, i.Item2, mapUrlProvider.GetDetailsUrl(i.Item1),
                                           i.Item3, mapUrlProvider.GetChildrenUrl(i.Item1)))
                .ToArray();

            var buildings = buildingTuples
                .Select(i => parentIds.Contains(i.Item1)
                                 ? new Building(i.Item1, i.Item2, buildingUrlProvider.GetDetailsUrl(i.Item1), maps)
                                 : new Building(i.Item1, i.Item2, buildingUrlProvider.GetDetailsUrl(i.Item1),
                                           i.Item3, buildingUrlProvider.GetChildrenUrl(i.Item1)))
                .ToArray();

            var campuses = campusTuples
                .Select(i => parentIds.Contains(i.Item1)
                                 ? new Campus(i.Item1, i.Item2, campusUrlProvider.GetDetailsUrl(i.Item1), buildings)
                                 : new Campus(i.Item1, i.Item2, campusUrlProvider.GetDetailsUrl(i.Item1),
                                           i.Item3, campusUrlProvider.GetChildrenUrl(i.Item1)))
                .ToArray();

            return new MapList(campuses, selectedId);
        }

        private static void FindParentIds(Stack<Guid> parentIds, Guid nodeId)
        {
            parentIds.Push(nodeId);
            if (nodeId == Guid.Empty)
                return;
            FindParentIds(parentIds, Data.GetParent(nodeId));
        }



    }

}
