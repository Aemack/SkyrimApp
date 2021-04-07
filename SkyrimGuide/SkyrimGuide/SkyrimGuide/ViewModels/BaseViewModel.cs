using SkyrimGuide.Models;
using SkyrimGuide.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Forms;

namespace SkyrimGuide.ViewModels
{
    public class BaseViewModel 
    {
        public string Title { get; set ; }
        
        List<object> Data { get; set; }
    }
}
