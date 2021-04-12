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
    public partial class UniqueGearTypesPage : ContentPage
    {
        public UniqueGearTypesPage()
        {
            InitializeComponent();
        }

        public void OnMore(object sender, EventArgs e)
        {
            var item = (ListView)sender;
            var gearType = item.SelectedItem.ToString();
            Navigation.PushAsync(new UniqueGearsPage(gearType));
        }
    }
}