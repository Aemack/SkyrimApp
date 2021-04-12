using SkyrimGuide.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace SkyrimGuide.ViewModels
{
    public class MerchantTypesViewModel: BaseViewModel
    {
        public List<string> MerchantTypes { get; set; }
        public MerchantTypesViewModel()
        {
            Title = "Merchandise";
            var ms = new MerchantsService();
            MerchantTypes = ms.GetMerchantTypes();
        }
    }
}
