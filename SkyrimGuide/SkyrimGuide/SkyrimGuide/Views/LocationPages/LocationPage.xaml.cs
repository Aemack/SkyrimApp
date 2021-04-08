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
    public partial class LocationPage : ContentPage
    {

        public Location Location { get; set; }
        public List<MapRow> MapData { get; set; }
        public LocationPage()
        {
            InitializeComponent();
            var ms = new MapService();
            MapData = ms.SetUpMap(Location);
        }

        public LocationPage(Location location)
        {
            Location = location;
            InitializeComponent();
            this.BindingContext = new LocationViewModel(Location);
        }


    }
}