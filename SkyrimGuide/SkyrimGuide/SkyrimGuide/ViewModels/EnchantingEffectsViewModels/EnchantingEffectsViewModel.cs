using SkyrimGuide.Models;
using SkyrimGuide.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace SkyrimGuide.ViewModels
{
    public class EnchantingEffectsViewModel : BaseViewModel
    {
        public List<EnchantingEffect> Effects { get; set; }

        public EnchantingEffectsViewModel()
        {
            Title = "Enchanting Effects";
            var es = new EnchantingEffectsService();
            Effects = es.GetAllEnchantingEffects();
        }
    }
}
