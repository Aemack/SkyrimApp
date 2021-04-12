using SkyrimGuide.Models;
using SkyrimGuide.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace SkyrimGuide.ViewModels
{
    public class FollowerViewModel : BaseViewModel
    {
        public Follower Follower { get; set; }
        public bool HasLocationLink { get; set; }
        public Location FollowerLocation { get; set; }

        public FollowerViewModel()
        {

        }

        public FollowerViewModel(Follower follower)
        {
            Follower = follower;
            Title = Follower.Name;
            var fs = new FollowersService();
            FollowerLocation = fs.GetLocationByFollower(Follower);
            if (FollowerLocation == null) return;
            HasLocationLink = true;
        }
    }
}
