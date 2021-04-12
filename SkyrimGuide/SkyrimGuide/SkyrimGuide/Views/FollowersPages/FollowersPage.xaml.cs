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
    public partial class FollowersPage : ContentPage
    {
        public FollowersPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            this.BindingContext = new FollowersViewModel();
        }

        public void Item_Clicked(object sender, EventArgs e)
        {
            var elem = (ListView)sender;
            var follower = (Follower)elem.SelectedItem;
            Navigation.PushAsync(new FollowerPage(follower));
        }

        private void CheckBox_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            var fs = new FollowersService();
            var itemChecked = (CheckBox)sender;
            Follower follower = itemChecked.BindingContext as Follower;
            fs.UpdateFollowerCheck(itemChecked.IsChecked, follower);
        }
    }
}