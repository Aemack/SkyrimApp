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
    public partial class UniqueGearPage : ContentPage
    {
        public Location GearLocation { get; set; }
        public UniqueGear Gear { get; set; }
        public Quest GearQuest { get; set; }
        public UniqueGearPage()
        {
            InitializeComponent();
        }

        public UniqueGearPage(UniqueGear gear)
        {
            Gear = gear;
            InitializeComponent();
            var gs = new UniqueGearService();
            GearLocation = gs.GetLocationByGear(Gear);
            GearQuest = gs.GetQuestByGear(Gear);
            this.BindingContext = new UniqueGearViewModel(Gear);
        }

        public void Location_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new LocationPage(GearLocation));
        }
        public void Quest_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new QuestPage(GearQuest));
        }

        private void CheckBox_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            var gs = new UniqueGearService();
            var gearChecked = (CheckBox)sender;
            gs.UpdateGearCheck(gearChecked.IsChecked, Gear);
        }
    }
}