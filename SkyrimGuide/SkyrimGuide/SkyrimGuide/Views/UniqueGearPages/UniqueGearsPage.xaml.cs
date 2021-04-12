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
    public partial class UniqueGearsPage : ContentPage
    {
        public string GearType { get; set; }
        public UniqueGearsPage()
        {
            InitializeComponent();
        }

        public UniqueGearsPage(string gearType)
        {
            GearType = gearType;
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            this.BindingContext = new UniqueGearsViewModel(GearType);
        }

        private void CheckBox_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            var gs = new UniqueGearService();
            var gearChecked = (CheckBox)sender;
            UniqueGear gear = gearChecked.BindingContext as UniqueGear;
            gs.UpdateGearCheck(gearChecked.IsChecked, gear);
        }

        public void Gear_Clicked(object sender, EventArgs e)
        {
            var item = (ListView)sender;
            var gear = (UniqueGear)item.SelectedItem;
            Navigation.PushAsync(new UniqueGearPage(gear));
        }
    }
}