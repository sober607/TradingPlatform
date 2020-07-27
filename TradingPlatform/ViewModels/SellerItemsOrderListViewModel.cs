﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TradingPlatform.ViewModels
{
    public class SellerItemsOrderListViewModel
    {
        [Display(Name = "Item name")]
        public string ItemName { get; set; }

        [Display(Name = "Price")]
        public decimal Price { get; set; }

        [Display(Name = "Currency")]
        public string CurrencyName { get; set; }

        [Display(Name = "Buyer")]
        public string BuyerName { get; set; }

        [Display(Name = "Buyer email")]
        public string BuyerEmail { get; set; }

        [Display(Name = "Order number")]
        public int OrderId { get; set; }

        [Display(Name = "Tracking number")]
        public string TrackingNumber { get; set; }

        [Display(Name = "Status")]
        public string Status { get; set; }

        [Display(Name = "Order time")]
        public string OrderDate { get; set; }

    }
}
