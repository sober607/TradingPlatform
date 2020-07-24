using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TradingPlatform.Models
{
    public class Item
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        public string? ImgUrl { get; set; }

        [Required]
        public decimal Price { get; set; }


        [Display(Name = "Is this service?")]
        public bool IsService { get; set; }

        [Display(Name = "Is it possible to ship/do in different country?")]
        public bool IsMultiCountryPossible { get; set; }

        public bool IsArchive { get; set; }

        public int? UserId { get; set; }

        public virtual User User { get; set; }

        public int? CategoryId { get; set; }

        public virtual Category Category { get; set; }

        public virtual List<Order> Orders { get; set; }
    }
}
