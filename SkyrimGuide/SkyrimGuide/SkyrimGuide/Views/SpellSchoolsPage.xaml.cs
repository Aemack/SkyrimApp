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
    public partial class SpellSchoolsPage : ContentPage
    {
        public SpellSchoolsPage()
        {
            InitializeComponent();
        }

        public void OnMore(object sender, EventArgs e)
        {
            var item = (ListView)sender;
            var spellType = item.SelectedItem.ToString();
            Navigation.PushAsync(new SpellsPage(spellType));
        }
    }
}