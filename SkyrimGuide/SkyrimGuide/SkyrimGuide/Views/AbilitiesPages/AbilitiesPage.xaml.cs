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
    public partial class AbilitiesPage : ContentPage
    {
        public string AbilityType { get; set; }
        public AbilitiesPage()
        {
            InitializeComponent();

        }


        public AbilitiesPage(string abilityType)
        {
            AbilityType = abilityType;
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            this.BindingContext = new AbilitiesViewModel(AbilityType);
        }

        public void Item_Clicked(object sender, EventArgs e)
        {
            var elem = (ListView)sender;
            var ability = (Ability)elem.SelectedItem;
            Navigation.PushAsync(new AbilityPage(ability));
        }

        private void CheckBox_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            var abs = new AbilitiesService();
            var itemChecked = (CheckBox)sender;
            Ability ability = itemChecked.BindingContext as Ability;
            abs.UpdateAbilityCheck(itemChecked.IsChecked, ability);
        }

    }
}