using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TradingPlatform.Models;

namespace TradingPlatform.ViewModels
{
    public class ItemAddViewModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        public IFormFile File { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Display(Name = "Is this service?")]
        public bool IsService { get; set; }

        [Display(Name = "Is it possible to ship/do in different country?")]
        public bool IsMultiCountryPossible { get; set; }

        public string UserName { get; set; }

        public int CategoryId { get; set; }

        public List<SelectListItem> Categories { get; set; }

        public Country Country { get; set; }

        public Status Status { get; set; }
    }

    public enum Status
    {
        InProcess,
        Added
    }
}
