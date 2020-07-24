using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TradingPlatform.ViewModels
{
    public class ItemOrderModel
    {
        public int ItemId { get; set; }
        public string ItemName { get; set; }

        public decimal Price { get; set; }

        public string BuyerName { get; set; }

        public string SellerName { get; set; }

        public bool PossibleToShipAnotherCountry { get; set; }

        public int Qty { get; set; }

        public string TrackingNumber { get; set; }

        public string Status { get; set; }

    }
}
