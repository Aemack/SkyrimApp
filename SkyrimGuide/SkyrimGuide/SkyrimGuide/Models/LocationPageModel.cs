using System;
using System.Collections.Generic;
using System.Text;

namespace SkyrimGuide.Models
{
    public class LocationPageModel
    {
        public Location Location { get; set; }
        public List<MapRow> MapData { get; set; }

        public LocationPageModel(Location location, List<MapRow> mapData)
        {
            Location = location;
            MapData = mapData;
        }
    }
}
