using SkyrimGuide.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace SkyrimGuide.ViewModels
{
    class AbilityTypesViewModel : BaseViewModel
    {
        public List<string> AbilityTypes { get; set; }
        public AbilityTypesViewModel()
        {
            Title = "Ability Types";
            var abs = new AbilitiesService();
            AbilityTypes = abs.GetTypeNames();
        }
    }
}
