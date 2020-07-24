using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using TradingPlatform.Repositories;
using TradingPlatform.ViewModels;

namespace TradingPlatform.Controllers
{
    public class ItemsController : Controller
    {
        private IItemRepository _itemRepository { get; set; }

        private IWebHostEnvironment _appEnvironment { get; set; }

        private ICategoryRepository _categoryRepository { get; set; }

        public ItemsController(IItemRepository itemrepository, IWebHostEnvironment appEnvironment, ICategoryRepository categoryRepository)
        {
            _itemRepository = itemrepository;
            _appEnvironment = appEnvironment;
            _categoryRepository = categoryRepository;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Category(int categoryId)
        {
            var itemsList = _itemRepository.GetCategorisedItems(categoryId);

            if (itemsList != null && itemsList.Count() > 0)
            {
                ViewBag.ItemsList = new List<ItemListViewModel>();
                ViewBag.CategoryName = _categoryRepository.GetCategoryName(categoryId);

                foreach (var t in itemsList)
                {
                    string noImg = @"/images/no-image.png";

                    if (t.ImgUrl == null)
                    {
                        t.ImgUrl = noImg;
                    }
                    ViewBag.ItemsList.Add(new ItemListViewModel { ItemId = t.Id, ItemName = t.Name, Price = t.Price, Currency = t.User.Country.Currency.ShortName, ImgUrl = t.ImgUrl });
                }
            }

            return View();
        }
    }
}
