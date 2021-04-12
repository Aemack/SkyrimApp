using SkyrimGuide.Models;
using SkyrimGuide.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace SkyrimGuide.ViewModels
{
    public class UniqueGearViewModel
    {
        public UniqueGear Item { get; set; }
        public bool HasLocationLink { get; set; }
        public bool HasQuestLink { get; set; }
        public Quest GearQuest { get; set; }
        public Location GearLocation { get; set; }

        public UniqueGearViewModel()
        {

        }

        public UniqueGearViewModel(UniqueGear item)
        {
            Item = item;
            var gs = new UniqueGearService();
            if (Item.Quest != "")
            {
                GearQuest = gs.GetQuestByGear(Item);
            }
            if (Item.Location != "")
            {
                GearLocation = gs.GetLocationByGear(Item);
            }
            HasQuestLink = (GearQuest != null);
            HasLocationLink = (GearLocation != null);

        }

    }
}
