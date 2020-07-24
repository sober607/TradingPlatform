using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TradingPlatform.Models
{
    public class User : IdentityUser
    {
        public string Name { get; set; }

        public virtual List<Item> Items { get; set; }

        public virtual List<Order> Orders { get; set; }

        public int? CountryId { get; set; }

        public virtual Country Country { get; set; }
    }
}
