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
    public partial class MerchantPage : ContentPage
    {

        public Location MerchantLocation { get; set; }
        public Merchant Merchant { get; set; }
        public MerchantPage()
        {
            InitializeComponent();
        }

        public MerchantPage(Merchant merchant)
        {
            Merchant = merchant;
            InitializeComponent();
            var ms = new MerchantsService();
            MerchantLocation = ms.GetLocationByMerchant(Merchant);
            this.BindingContext = new MerchantViewModel(Merchant);
        }

        public void Location_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new LocationPage(MerchantLocation));
        }

        private void CheckBox_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            var ms = new MerchantsService();
            var merchantChecked = (CheckBox)sender;
            ms.UpdateMerchantCheck(merchantChecked.IsChecked, Merchant);
        }
    }
}