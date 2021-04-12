using SkyrimGuide.Models;
using SkyrimGuide.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace SkyrimGuide.ViewModels
{
    class ShoutViewModel : BaseViewModel
    {
        public DragonShout Shout { get; set; }
        public bool HasLocationlink { get; set; }
        public Location ShoutLocation { get; set; }

        public ShoutViewModel()
        {

        }

        public ShoutViewModel(DragonShout shout)
        {
            Shout = shout;
            var ss = new ShoutService();
            ShoutLocation = ss.GetLocationByShout(Shout);
            if (ShoutLocation == null) return;
            HasLocationlink = true;
        }
    }
}
