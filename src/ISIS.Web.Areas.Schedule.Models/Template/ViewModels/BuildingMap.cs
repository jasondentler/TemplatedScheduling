namespace ISIS.Web.Areas.Schedule.Models.Template.ViewModels
{
    public class BuildingMap
    {
        public string Name { get; set; }
        public string MapImageUrl { get; set; }
        public string MapRoomDataUrl { get; set; }
        public string AvailabilityUrl { get; set; }

        public BuildingMap(
            string name, 
            string mapImageUrl, 
            string mapRoomDataUrl,
            string availabilityUrl)
        {
            Name = name;
            MapImageUrl = mapImageUrl;
            MapRoomDataUrl = mapRoomDataUrl;
            AvailabilityUrl = availabilityUrl;
        }
    }
}
