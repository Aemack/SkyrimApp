using SkyrimGuide.Models;
using SkyrimGuide.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace SkyrimGuide.ViewModels
{
    public class CollectibleItemTypesViewModel : BaseViewModel
    {
        public List<string> ItemTypes { get; set; }
        public CollectibleItemTypesViewModel()
        {
            Title = "Item Types";
            var cis = new CollectibleItemsService();
            ItemTypes = cis.GetTypeNames();
        }
    }
}
