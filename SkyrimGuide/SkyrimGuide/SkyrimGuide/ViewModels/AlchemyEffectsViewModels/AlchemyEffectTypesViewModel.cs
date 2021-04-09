using SkyrimGuide.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace SkyrimGuide.ViewModels
{
    public class AlchemyEffectTypesViewModel : BaseViewModel
    {
        public List<string> AlchemyEffectTypes { get; set; }
        public AlchemyEffectTypesViewModel()
        {
            Title = "Effects";
            var aes = new AlchemyEffectsService();
            AlchemyEffectTypes = aes.GetEffectNames();
        }
    }
}
