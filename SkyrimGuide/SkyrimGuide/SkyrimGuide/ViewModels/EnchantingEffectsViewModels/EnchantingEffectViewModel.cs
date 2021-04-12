using SkyrimGuide.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SkyrimGuide.ViewModels
{
    public class EnchantingEffectViewModel : BaseViewModel
    {
        public EnchantingEffect Effect { get; set; }

        public EnchantingEffectViewModel()
        {

        }

        public EnchantingEffectViewModel(EnchantingEffect effect)
        {
            Effect = effect;
            Title = effect.EnchantmentName;
        }
    }
}
