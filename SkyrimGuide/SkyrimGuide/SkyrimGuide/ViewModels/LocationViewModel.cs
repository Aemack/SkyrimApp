using SkyrimGuide.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace SkyrimGuide.ViewModels
{
    class LocationViewModel
    {
        public List<string> Regions { get; set; }
        public LocationViewModel()
        {
            var ls = new LocationService();
            Regions = ls.GetRegionNames();
        }
    }
}
