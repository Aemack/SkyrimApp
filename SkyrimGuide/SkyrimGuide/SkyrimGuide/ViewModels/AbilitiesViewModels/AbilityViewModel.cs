using SkyrimGuide.Models;
using SkyrimGuide.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace SkyrimGuide.ViewModels
{
    public class AbilityViewModel
    {
        public Ability Ability{ get; set; }
        public bool HasLocationLink { get; set; }
        public Location AbilityLocation { get; set; }

        public AbilityViewModel()
        {

        }

        public AbilityViewModel(Ability ability)
        {
            Ability = ability;
            var abs = new AbilitiesService();
            var itemLocation = abs.GetLocationByAbility(ability);
            if (itemLocation == null) return;
            HasLocationLink = true;
        }
    }
}
