﻿using System;
using System.Collections.Generic;
using ISIS.Web.Areas.Facilities.Models.Tree;
using ISIS.Web.Models;

namespace ISIS.Web.Areas.Facilities.Models.Map.ViewModels
{
    public class Details : JsonSerializable, IMapList 
    {
        public Guid Id { get; set; }
        public string MapName { get; set; }
        public Guid BuildingId { get; set; }
        public Guid CampusId { get; set; }
        public string CampusName { get; set; }
        public string MapImageUrl { get; set; }
        public string BuildingName { get; set; }
        public IEnumerable<ITreeItem> RootItems { get; private set; }
        public Guid SelectedItem { get; private set; }

        public Details(IMapList tree,
            Guid id,
            string mapName,
            Guid buildingId,
            string buildingName,
            Guid campusId,
            string campusName,
            string mapImageUrl)
        {
            Id = id;
            MapName = mapName;
            BuildingId = buildingId;
            BuildingName = buildingName;
            CampusId = campusId;
            CampusName = campusName;
            MapImageUrl = mapImageUrl;
            RootItems = tree.RootItems;
            SelectedItem = tree.SelectedItem;
        }
    }
}
