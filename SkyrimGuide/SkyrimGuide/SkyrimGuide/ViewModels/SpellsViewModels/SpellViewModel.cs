using SkyrimGuide.Models;
using SkyrimGuide.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace SkyrimGuide.ViewModels
{
    public class SpellViewModel : BaseViewModel
    {
        public Spell Spell { get; set; }
        public bool HasLocationLinks { get; set; }
        public List<Location> SpellLocations { get; set; }
        public SpellViewModel()
        {

        }

        public SpellViewModel(Spell spell)
        {
            Spell = spell;
            Title = spell.Name;
            var ss = new SpellsService();
            SpellLocations = ss.GetLocationsBySpell(Spell);
            if (SpellLocations.Count == 0) return;
            HasLocationLinks = true;
        }
    }
}
