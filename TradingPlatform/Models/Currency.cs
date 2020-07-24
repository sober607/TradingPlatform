using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TradingPlatform.Models
{
    public class Currency
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string ShortName { get; set; }

        public int? Code { get; set; }

        public decimal Rate { get; set; }

        public string RateLastSyncTime { get; set; }

        public virtual List<Country> Countries { get; set; }
    }
}
