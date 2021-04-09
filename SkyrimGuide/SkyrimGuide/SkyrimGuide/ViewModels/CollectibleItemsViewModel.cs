using SkyrimGuide.Models;
using SkyrimGuide.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace SkyrimGuide.ViewModels
{
    public class CollectibleItemsViewModel : BaseViewModel
    {
        public string ItemType { get; set; }
        public List<CollectibleItem> Items { get; set; }

        public CollectibleItemsViewModel()
        {
            Title = ItemType;
            var cis = new CollectibleItemsService();
            Items = cis.GetItemsByType(ItemType);
        }

        public CollectibleItemsViewModel(string itemType)
        {
            ItemType = itemType;
            Title = ItemType;
            var cis = new CollectibleItemsService();
            Items = cis.GetItemsByType(ItemType);
        }


    }
}
