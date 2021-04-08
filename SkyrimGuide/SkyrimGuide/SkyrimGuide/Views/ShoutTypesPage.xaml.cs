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
    public partial class ShoutTypesPage : ContentPage
    {
        public ShoutTypesPage()
        {
            InitializeComponent();
        }

        public void OnMore(object sender, EventArgs e)
        {
            var item = (ListView)sender;
            var shoutType = item.SelectedItem.ToString();
            Navigation.PushAsync(new ShoutsPage(shoutType));
        }
    }
}