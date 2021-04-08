using SkyrimGuide.Models;
using SkyrimGuide.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace SkyrimGuide.ViewModels
{
    public class ShoutsViewModel : BaseViewModel
    {
        public string ShoutType { get; set; }
        public List<DragonShout> Shouts { get; set; }
        public ShoutsViewModel()
        {
            var ss = new ShoutService();
            Shouts = ss.GetShoutsByType(ShoutType);
            Title = ShoutType;
        }

        public ShoutsViewModel(string shoutType)
        {
            ShoutType = shoutType;
            var ss = new ShoutService();
            Shouts = ss.GetShoutsByType(ShoutType);
            Title = ShoutType;
        }
    }
}
