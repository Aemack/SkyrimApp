using SkyrimGuide.Models;
using SkyrimGuide.Services;
using SkyrimGuide.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SkyrimGuide.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EnchantingEffectPage : ContentPage
    {
        public EnchantingEffect Effect { get; set; }
        public EnchantingEffectPage()
        {
            InitializeComponent();
        }

        public EnchantingEffectPage(EnchantingEffect effect)
        {
            Effect = effect;
            InitializeComponent();
            this.BindingContext = new EnchantingEffectViewModel(Effect);
        }

        private void CheckBox_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            var es = new EnchantingEffectsService();
            var itemChecked = (CheckBox)sender;
            es.UpdateEnchantingEffectCheck(itemChecked.IsChecked, Effect);
        }
    }
}