using SkyrimGuide.Models;
using SkyrimGuide.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace SkyrimGuide.ViewModels
{
    public class UniqueGearsViewModel : BaseViewModel
    {
        public string GearType { get; set; }
        public List<UniqueGear> Gear { get; set; }
        public UniqueGearsViewModel()
        {
            var gs = new UniqueGearService();
            Gear = gs.GetGearByType(GearType);
            Title = GearType;
        }
        public UniqueGearsViewModel(string gearType)
        {
            GearType = gearType;
            var gs = new UniqueGearService();
            Gear = gs.GetGearByType(GearType);
            Title = GearType;
        }
    }
}
