using SkyrimGuide.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace SkyrimGuide.ViewModels
{
    public class ShoutTypesViewModel : BaseViewModel
    {
        public List<string> ShoutTypes { get; set; }
        public ShoutTypesViewModel()
        {
            Title = "Shout Types";
            var ss = new ShoutService();
            ShoutTypes = ss.GetShoutTypes();
        }
    }
}
