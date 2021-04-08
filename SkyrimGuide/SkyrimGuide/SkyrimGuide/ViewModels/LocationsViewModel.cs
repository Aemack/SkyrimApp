using SkyrimGuide.Models;
using SkyrimGuide.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace SkyrimGuide.ViewModels
{
    public class LocationsViewModel : BaseViewModel
    {
        public string Region { get; set; }

        public List<Location> Locations { get; set; }

        public LocationsViewModel()
        {
            var ls = new LocationService();
            Locations = ls.GetLocationsByRegion(Region);
            Title = Region;
        }

        public LocationsViewModel(string region)
        {
            Region = region;
            var ls = new LocationService();
            Locations = ls.GetLocationsByRegion(Region);
            Title = Region;
        }

    }
}
