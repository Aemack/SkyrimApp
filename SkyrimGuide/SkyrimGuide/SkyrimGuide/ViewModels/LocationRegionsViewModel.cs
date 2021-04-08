using SkyrimGuide.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace SkyrimGuide.ViewModels
{
    public class LocationRegionsViewModel :BaseViewModel
    {
        public List<string> Regions { get; set; }
        public LocationRegionsViewModel()
        {
            var ls = new LocationService();
            Regions = ls.GetRegionNames();
            Title = "Regions";
            
        }
    }
}
