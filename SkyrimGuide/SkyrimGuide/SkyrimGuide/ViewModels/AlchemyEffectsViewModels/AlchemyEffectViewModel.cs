using SkyrimGuide.Models;
using SkyrimGuide.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace SkyrimGuide.ViewModels
{
    public class AlchemyEffectViewModel : BaseViewModel
    {
        public string AlchemyEffectType { get; set; }
        public List<AlchemyEffect> AlchemyIngredients { get; set; }
        public AlchemyEffectViewModel()
        {
            Title = AlchemyEffectType;
            var aes = new AlchemyEffectsService();
            AlchemyIngredients = aes.GetAlchemyEffectsByName(AlchemyEffectType);
        }

        public AlchemyEffectViewModel(string effect)
        {
            AlchemyEffectType = effect;
            Title = AlchemyEffectType;
            var aes = new AlchemyEffectsService();
            AlchemyIngredients = aes.GetAlchemyIngredientsByEffect(AlchemyEffectType);
        }
    }
}
