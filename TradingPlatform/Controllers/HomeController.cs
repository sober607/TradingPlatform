using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.WebSockets;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TradingPlatform.Infrastructure.Services.Implementations;
using TradingPlatform.Infrastructure.Services.Interfaces;
using TradingPlatform.Models;
using TradingPlatform.Repositories;

namespace TradingPlatform.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private ICategoryRepository _categoryRepository;




        public HomeController(ILogger<HomeController> logger, ICategoryRepository categoryRepository)
        {
            _logger = logger;
            _categoryRepository = categoryRepository;
            
        }

        public IActionResult Index(string username)
        {
            
            ViewBag.Categories = _categoryRepository.GetAllCategories();

            if (username == null)
            {
            if (User.Identity.IsAuthenticated)
            {
                username = User.Identity.Name;
            }
            else
            {
                username = Guid.NewGuid().ToString();
            }
            }

            ViewBag.UserName = username;

                return View();
        }





        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
