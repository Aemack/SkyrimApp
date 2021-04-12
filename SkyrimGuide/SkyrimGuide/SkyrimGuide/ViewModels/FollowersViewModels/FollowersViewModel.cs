using SkyrimGuide.Models;
using SkyrimGuide.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace SkyrimGuide.ViewModels
{
    public class FollowersViewModel : BaseViewModel
    {
        public List<Follower> Followers { get; set; }
        public FollowersViewModel()
        {
            Title = "Followers";
            var fs = new FollowersService();
            Followers = fs.GetAllFollowers();
        }
    }
}
