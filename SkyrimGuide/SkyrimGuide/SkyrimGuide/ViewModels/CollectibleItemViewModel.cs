using SkyrimGuide.Models;
using SkyrimGuide.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace SkyrimGuide.ViewModels
{
    public class CollectibleItemViewModel : BaseViewModel
    {
        public CollectibleItem Item { get; set; }
        public bool HasLocationLink { get; set; }
        public Location ItemLocation { get; set; }

        public CollectibleItemViewModel()
        {

        }

        public CollectibleItemViewModel(CollectibleItem item)
        {
            Item = item;
            var cis = new CollectibleItemsService();
            var itemLocation = cis.GetLocationByItem(Item);
            if (itemLocation == null) return;
            HasLocationLink = true;
        }
    }
}
