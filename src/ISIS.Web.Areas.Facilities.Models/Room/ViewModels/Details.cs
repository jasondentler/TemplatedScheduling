using System;
using System.Collections.Generic;
using ISIS.Web.Areas.Facilities.Models.Tree;
using ISIS.Web.Models;

namespace ISIS.Web.Areas.Facilities.Models.Room.ViewModels
{
    public class Details : JsonSerializable, IMapList 
    {
        public Guid Id { get; set; }
        public string RoomName { get; set; }
        public Guid MapId { get; set; }
        public string MapName { get; set; }
        public Guid BuildingId { get; set; }
        public Guid CampusId { get; set; }
        public string CampusName { get; set; }
        public string MapImageUrl { get; set; }
        public Polygon RoomPolygon { get; set; }
        public string RoomType { get; set; }
        public IEnumerable<string> RoomTypes { get; set; }
        public string BuildingName { get; set; }
        public IEnumerable<ITreeItem> RootItems { get; private set; }
        public Guid SelectedItem { get; private set; }

        public Details(IMapList tree,
            Guid id,
            string roomName,
            Guid mapId,
            string mapName,
            Guid buildingId,
            string buildingName,
            Guid campusId,
            string campusName,
            string mapImageUrl,
            Polygon roomPolygon,
            string roomType,
            IEnumerable<string> roomTypes)
        {
            Id = id;
            RoomName = roomName;
            MapId = mapId;
            MapName = mapName;
            BuildingId = buildingId;
            BuildingName = buildingName;
            CampusId = campusId;
            CampusName = campusName;
            MapImageUrl = mapImageUrl;
            RoomPolygon = roomPolygon;
            RoomType = roomType;
            RoomTypes = roomTypes;
            RootItems = tree.RootItems;
            SelectedItem = tree.SelectedItem;
        }

    }
}
