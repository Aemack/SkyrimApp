using SkyrimGuide.Models;
using SkyrimGuide.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace SkyrimGuide.ViewModels
{
    public class MerchantViewModel
    {
        public Merchant Merchant { get; set; }
        public bool HasLocationLink { get; set; }
        public Location MerchantLocation { get; set; }
        public MerchantViewModel()
        {

        }

        public MerchantViewModel(Merchant merchant)
        {
            Merchant = merchant;
            var ms = new MerchantsService();
            MerchantLocation = ms.GetLocationByMerchant(Merchant);
            if (MerchantLocation == null) return;
            HasLocationLink = true;
        }
    }
}
