using SkyrimGuide.Models;
using SkyrimGuide.Services;
using SkyrimGuide.ViewModels;
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
    public partial class CollectibleItemPage : ContentPage
    {
        public CollectibleItem Item { get; set; }
        public Location ItemLocation { get; set; }

        public CollectibleItemPage()
        {
            InitializeComponent();
        }

        public CollectibleItemPage(CollectibleItem item)
        {
            Item = item;
            InitializeComponent();
            var cis = new CollectibleItemsService();
            ItemLocation = cis.GetLocationByItem(Item);
            this.BindingContext = new CollectibleItemViewModel(Item);
        }

        public void Location_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new LocationPage(ItemLocation));
        }

        private void CheckBox_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            var cis = new CollectibleItemsService();
            var itemChecked = (CheckBox)sender;
            cis.UpdateItemCheck(itemChecked.IsChecked, Item);
        }

    }
}