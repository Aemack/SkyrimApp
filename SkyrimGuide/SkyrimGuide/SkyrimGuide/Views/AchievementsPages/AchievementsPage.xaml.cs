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
    public partial class AchievementsPage : ContentPage
    {
        public AchievementsPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            this.BindingContext = new AchievementsViewModel();
        }

        public void Item_Clicked(object sender, EventArgs e)
        {
            var elem = (ListView)sender;
            var achievement = (Achievement)elem.SelectedItem;
            Navigation.PushAsync(new AchievementPage(achievement));
        }

        private void CheckBox_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            var acs = new AchievementsService();
            var itemChecked = (CheckBox)sender;
            Achievement achievement = itemChecked.BindingContext as Achievement;
            acs.UpdateAchievementCheck(itemChecked.IsChecked, achievement);
        }
    }
}