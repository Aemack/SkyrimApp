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
    public partial class FollowerPage : ContentPage
    {
        public Follower Follower{ get; set; }
        public Location FollowerLocation { get; set; }
        public FollowerPage()
        {
            InitializeComponent();
        }

        public FollowerPage(Follower follower)
        {
            Follower = follower;
            InitializeComponent();
            var fs = new FollowersService();
            FollowerLocation = fs.GetLocationByFollower(Follower);
            this.BindingContext = new FollowerViewModel(Follower);
        }

        public void Location_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new LocationPage(FollowerLocation));
        }

        private void CheckBox_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            var fs = new FollowersService();
            var followerChecked = (CheckBox)sender;
            fs.UpdateFollowerCheck(followerChecked.IsChecked, Follower);
        }
    }
}