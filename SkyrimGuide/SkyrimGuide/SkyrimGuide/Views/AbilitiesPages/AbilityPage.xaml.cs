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
    public partial class AbilityPage : ContentPage
    {

        public Ability Ability { get; set; }
        public Location ItemLocation { get; set; }
        public AbilityPage()
        {
            InitializeComponent();
        }

        public AbilityPage(Ability item)
        {
            Ability = item;
            InitializeComponent();
            var abs = new AbilitiesService();
            ItemLocation = abs.GetLocationByAbility(Ability);
            this.BindingContext = new AbilityViewModel(Ability);
        }

        public void Location_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new LocationPage(ItemLocation));
        }

        private void CheckBox_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            var abs = new AbilitiesService();
            var itemChecked = (CheckBox)sender;
            abs.UpdateAbilityCheck(itemChecked.IsChecked, Ability);
        }

    }
}