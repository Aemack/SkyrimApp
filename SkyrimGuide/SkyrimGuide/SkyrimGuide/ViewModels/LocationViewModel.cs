using SkyrimGuide.Models;
using SkyrimGuide.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace SkyrimGuide.ViewModels
{
    public class LocationViewModel : BaseViewModel
    {
        public Location Location { get; set; }
        public List<MapRow> MapData { get; set; }

        public LocationViewModel()
        {
        }

        public LocationViewModel(Location location)
        {
            Location = location;
            var ms = new MapService();
            MapData = ms.SetUpMap(Location);
        }
    }
}
