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
    public partial class AlchemyEffectPage : ContentPage
    {
        public string EffectType { get; set; }
        public AlchemyEffectPage()
        {
            InitializeComponent();
        }

        public AlchemyEffectPage(string effectType)
        {
            EffectType = effectType;
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            this.BindingContext = new AlchemyEffectViewModel(EffectType);
        }

        public void Item_Clicked(object sender, EventArgs e)
        {
            var elem = (ListView)sender;
            var ingredient = elem.SelectedItem as AlchemyEffect;
            Navigation.PushAsync(new AlchemyIngredientPage(ingredient.ItemName));
        }

        private void CheckBox_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            var aes = new AlchemyEffectsService();
            var itemChecked = (CheckBox)sender;
            var obj = itemChecked.BindingContext as AlchemyEffect;
            aes.UpdateAlchemyEffectCheck(itemChecked.IsChecked, obj);
        }
    }
}