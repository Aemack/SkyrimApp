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
    public partial class ShoutPage : ContentPage
    {
        public Location ShoutLocation{ get; set; }
        public DragonShout Shout { get; set; }

        public ShoutPage()
        {
            InitializeComponent();
        }

        public ShoutPage(DragonShout shout)
        {
            Shout = shout;
            InitializeComponent();
            var ss = new ShoutService();
            ShoutLocation = ss.GetLocationByShout(Shout);
            this.BindingContext = new ShoutViewModel(Shout);
        }

        public void Location_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new LocationPage(ShoutLocation));
        }

        private void CheckBox_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            var ls = new ShoutService();
            var locationChecked = (CheckBox)sender;
            ls.UpdateShoutCheck(locationChecked.IsChecked, Shout);
        }
    }
}