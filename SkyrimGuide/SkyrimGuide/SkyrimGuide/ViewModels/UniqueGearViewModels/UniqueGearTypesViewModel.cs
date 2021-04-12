using SkyrimGuide.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace SkyrimGuide.ViewModels
{
    public class UniqueGearTypesViewModel:BaseViewModel
    {
        public List<string> GearTypes { get; set; }
        public UniqueGearTypesViewModel()
        {
            Title = "Gear Types";
            var gs = new UniqueGearService();
            GearTypes = gs.GetGearTypes();
        }
    }
}
