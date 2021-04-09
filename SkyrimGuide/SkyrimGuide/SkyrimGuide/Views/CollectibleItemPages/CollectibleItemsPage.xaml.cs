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
    public partial class CollectibleItemsPage : ContentPage
    {
        public string ItemType { get; set; }
        public CollectibleItemsPage()
        {
            InitializeComponent();
        }

        public CollectibleItemsPage(string itemType)
        {
            ItemType = itemType;
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            this.BindingContext = new CollectibleItemsViewModel(ItemType);
        }

        public void Item_Clicked(object sender, EventArgs e)
        {
            var elem = (ListView)sender;
            var item = (CollectibleItem)elem.SelectedItem;
            Navigation.PushAsync(new CollectibleItemPage(item));
        }

        private void CheckBox_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            var cis = new CollectibleItemsService();
            var itemChecked = (CheckBox)sender;
            CollectibleItem item = itemChecked.BindingContext as CollectibleItem;
            cis.UpdateItemCheck(itemChecked.IsChecked, item);
        }

    }
}