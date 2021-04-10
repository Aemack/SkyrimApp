using SkyrimGuide.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace SkyrimGuide.ViewModels
{
    public class SpellSchoolsViewModel : BaseViewModel
    {
        public List<string> SpellSchools { get; set; }

        public SpellSchoolsViewModel()
        {
            Title = "Spell Schools";
            var ss = new SpellsService();
            SpellSchools = ss.GetSpellTypes();
        }
    }
}
