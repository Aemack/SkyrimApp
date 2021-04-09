using SkyrimGuide.Models;
using SkyrimGuide.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace SkyrimGuide.ViewModels
{
    public class AlchemyIngredientViewModel : BaseViewModel
    {
        public List<AlchemyEffect> AlchemyIngredients{ get; set; }
        public AlchemyIngredientViewModel()
        {

        }

        public AlchemyIngredientViewModel(string effect)
        {
            Title = effect;
            var aes = new AlchemyEffectsService();
            AlchemyIngredients = aes.GetAlchemyEffectsByName(effect);
        }
    }
}
