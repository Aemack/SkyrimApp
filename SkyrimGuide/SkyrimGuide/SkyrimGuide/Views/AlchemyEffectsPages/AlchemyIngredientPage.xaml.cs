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
    public partial class AlchemyIngredientPage : ContentPage
    {
        public string EffectType { get; set; }
        public AlchemyIngredientPage()
        {
            InitializeComponent();
        }

        public AlchemyIngredientPage(string effectType)
        {
            EffectType = effectType;
            InitializeComponent();
            this.BindingContext = new AlchemyIngredientViewModel(EffectType);

        }

        private void Check_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            var abs = new AlchemyEffectsService();
            var itemChecked = (CheckBox)sender;
            var obj = itemChecked.BindingContext as AlchemyEffect;
            abs.UpdateAlchemyEffectCheck(itemChecked.IsChecked, obj);
        }
    }
}