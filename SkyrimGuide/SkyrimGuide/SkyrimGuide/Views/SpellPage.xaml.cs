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
    public partial class SpellPage : ContentPage
    {
        public Spell Spell { get; set; }
        public List<Location> SpellLocations { get; set; }
        public SpellPage()
        {
            InitializeComponent();
        }

        public SpellPage(Spell spell)
        {
            Spell = spell;
            InitializeComponent();
            this.BindingContext = new SpellViewModel(Spell);
        }

        private void LocationPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            var locationPicker = (Picker)sender;
            Location selectedLocation = locationPicker.SelectedItem as Location;
            Navigation.PushAsync(new LocationPage(selectedLocation));
        }


        private void CheckBox_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            var ss = new SpellsService();
            var bookChecked = (CheckBox)sender;
            ss.UpdateSpellCheck(bookChecked.IsChecked, Spell);
        }
    }
}