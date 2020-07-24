using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TradingPlatform.ViewModels
{
    public class ItemListViewModel
    {
        public int ItemId { get; set; }

        public string ItemName { get; set; }

        public decimal Price { get; set; }

        public string Currency { get; set; }

        public string ImgUrl { get; set; }
    }
}
