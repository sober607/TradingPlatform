using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TradingPlatform.Models
{
    public class Country
    {
        public int Id { get; set; }

        [Required]
        [RegularExpression("^[a-zA-Z *$]", ErrorMessage = "Country name must containe only letters")]
        public string Name { get; set; }

        public virtual List<City> Cities { get; set; }

        public int? CurrencyId { get; set; }

        public virtual Currency Currency { get; set; }

        public virtual List<User> Users { get; set; }

    }
}
