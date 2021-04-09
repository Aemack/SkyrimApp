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
    public partial class ShoutsPage : ContentPage
    {
        public string SType { get; }

        public ShoutsPage()
        {
            InitializeComponent();
        }

        public ShoutsPage(string shoutType)
        {
            SType = shoutType;
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            this.BindingContext = new ShoutsViewModel(SType);
        }

        public void Shout_Clicked(object sender, EventArgs e)
        {
            var item = (ListView)sender;
            var shout = (DragonShout)item.SelectedItem;
            Navigation.PushAsync(new ShoutPage(shout));
        }

        private void CheckBox_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            var ss = new ShoutService();
            var shoutChecked = (CheckBox)sender;
            DragonShout shout = shoutChecked.BindingContext as DragonShout;
            ss.UpdateShoutCheck(shoutChecked.IsChecked, shout);
        }
    }
}