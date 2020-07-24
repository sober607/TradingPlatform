using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TradingPlatform.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string ItemName { get; set; }

        public decimal Price { get; set; }

        public int? UserId { get; set; }

        public virtual User User { get; set; }

        public int Qty { get; set; }

        public int? ItemId { get; set; }

        public virtual Item Item { get; set; }

        public string TrackingNumber { get; set; }

        public string Status { get; set; }

        public string DateTime { get; set; }
    }
}
