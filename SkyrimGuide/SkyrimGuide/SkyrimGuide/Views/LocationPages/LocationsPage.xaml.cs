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
    public partial class LocationsPage : ContentPage
    {

        public string Region { get; }

        public LocationsPage()
        {
            InitializeComponent();
        }

        public LocationsPage(string region)
        {
            Region= region;
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            this.BindingContext = new LocationsViewModel(Region);
        }


        public void Location_Clicked(object sender, EventArgs e)
        {
            var item = (ListView)sender;
            var location = (Location)item.SelectedItem;
            Navigation.PushAsync(new LocationPage(location));
        }

        private void CheckBox_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            var ls = new LocationService();
            var locationChecked = (CheckBox)sender;
            Location location = locationChecked.BindingContext as Location;
            ls.UpdateLocationCheck(locationChecked.IsChecked, location);
        }
    }
}