using SkyrimGuide.Models;
using SkyrimGuide.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace SkyrimGuide.ViewModels
{
    public class AbilitiesViewModel : BaseViewModel
    {
        public string AbilityType { get; set; }
        public List<Ability> Abilities { get; set; }

        public AbilitiesViewModel()
        {
            Title = AbilityType;
            var abs = new AbilitiesService();
            Abilities = abs.GetAbilitiesByType(AbilityType);
        }

        public AbilitiesViewModel(string itemType)
        {
            AbilityType = itemType;
            Title = AbilityType;
            var abs = new AbilitiesService();
            Abilities = abs.GetAbilitiesByType(AbilityType);
        }

    }
}
