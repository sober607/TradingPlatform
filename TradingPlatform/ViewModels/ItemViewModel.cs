using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TradingPlatform.ViewModels
{
    public class ItemViewModel
    {
        public int ItemId { get; set; }

        public string ItemName { get; set; }

        public string ItemDescription { get; set; }

        public decimal SellerPrice { get; set; }

        public string SellerCurrency { get; set; }

        public decimal BuyerPrice { get; set; }

        public string BuyerCurrency { get; set; }

        public string ImgUrl { get; set; }

    }
}
