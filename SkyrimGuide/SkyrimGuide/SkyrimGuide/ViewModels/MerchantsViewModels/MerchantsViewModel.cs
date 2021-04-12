using SkyrimGuide.Models;
using SkyrimGuide.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace SkyrimGuide.ViewModels
{
    public class MerchantsViewModel : BaseViewModel
    {
        public string MerchantType { get; set; }
        public List<Merchant> Merchants { get; set; }
        public MerchantsViewModel()
        {
            var ms = new MerchantsService();
            Merchants = ms.GetMerchantsByType(MerchantType);
            Title = MerchantType;
        }

        public MerchantsViewModel(string merchantType)
        {
            MerchantType = merchantType;
            var ms = new MerchantsService();
            Merchants = ms.GetMerchantsByType(MerchantType);
            Title = MerchantType;
        }
    }
}
