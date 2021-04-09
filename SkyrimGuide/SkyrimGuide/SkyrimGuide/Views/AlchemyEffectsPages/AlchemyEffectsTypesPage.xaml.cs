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
    public partial class AlchemyEffectsTypesPage : ContentPage
    {
        public AlchemyEffectsTypesPage()
        {
            InitializeComponent();
        }

        public void OnMore(object sender, EventArgs e)
        {
            var item = (ListView)sender;
            var effectType = item.SelectedItem.ToString();
            Navigation.PushAsync(new AlchemyEffectPage(effectType));
        }
    }
}