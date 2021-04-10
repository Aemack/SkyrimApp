using SkyrimGuide.Models;
using SkyrimGuide.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace SkyrimGuide.ViewModels
{
    public class SpellsViewModel : BaseViewModel
    {
        public string SpellSchool { get; set; }
        public List<Spell> Spells { get; set; }

        public SpellsViewModel()
        {
            var ss = new SpellsService();
            Spells = ss.GetSpellsByType(SpellSchool);
            Title = SpellSchool;
        }

        public SpellsViewModel(string spellSchool)
        {
            SpellSchool = spellSchool;
            var ss = new SpellsService();
            Spells = ss.GetSpellsByType(SpellSchool);
            Title = SpellSchool;
        }
    }
}
