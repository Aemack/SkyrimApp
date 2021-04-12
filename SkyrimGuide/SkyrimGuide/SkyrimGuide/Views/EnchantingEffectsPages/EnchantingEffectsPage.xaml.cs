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
    public partial class EnchantingEffectsPage : ContentPage
    {
        public EnchantingEffectsPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            this.BindingContext = new EnchantingEffectsViewModel();
        }

        public void Item_Clicked(object sender, EventArgs e)
        {
            var elem = (ListView)sender;
            var effect = (EnchantingEffect)elem.SelectedItem;
            Navigation.PushAsync(new EnchantingEffectPage(effect));
        }

        private void CheckBox_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            var es = new EnchantingEffectsService();
            var itemChecked = (CheckBox)sender;
            EnchantingEffect effect = itemChecked.BindingContext as EnchantingEffect;
            es.UpdateEnchantingEffectCheck(itemChecked.IsChecked, effect);
        }
    }
}