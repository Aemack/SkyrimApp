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
    public partial class MerchantsPage : ContentPage
    {
        public string MerchantType { get; set; }
        public MerchantsPage()
        {
            InitializeComponent();
        }

        public MerchantsPage(string merchantType)
        {
            MerchantType = merchantType;
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            this.BindingContext = new MerchantsViewModel(MerchantType);
        }

        public void Merchant_Clicked(object sender, EventArgs e)
        {
            var item = (ListView)sender;
            var merchant = (Merchant)item.SelectedItem;
            Navigation.PushAsync(new MerchantPage(merchant));
        }

        private void CheckBox_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            var ms = new MerchantsService();
            var merchantChecked = (CheckBox)sender;
            Merchant merchant = merchantChecked.BindingContext as Merchant;
            ms.UpdateMerchantCheck(merchantChecked.IsChecked, merchant);
        }
    }
}