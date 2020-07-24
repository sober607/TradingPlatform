using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using TradingPlatform.Infrastructure.Services.Interfaces;
using TradingPlatform.Repositories;
using TradingPlatform.ViewModels;

namespace TradingPlatform.Controllers
{
    public class ItemController : Controller
    {
        public IFileService _fileService { get; set; }

        public IWebHostEnvironment _appEnvironment { get; set; }

        public IItemRepository _repository { get; set; }

        public IUserRepository _userRepository { get; set; }

        public ICategoryRepository _categoryRepository { get; set; }

        public IOrderRepository _orderRepository { get; set; }

        public IMessageService _messageService { get; set; }

        public ItemController(IFileService fileService, IWebHostEnvironment appEnvironment, IItemRepository repository, IUserRepository userRepository, ICategoryRepository categoryRepository, IOrderRepository orderRepository, IMessageService messageService)
        {
            _fileService = fileService;
            _appEnvironment = appEnvironment;
            _repository = repository;
            _userRepository = userRepository;
            _categoryRepository = categoryRepository;
            _orderRepository = orderRepository;
            _messageService = messageService;
        }
        public IActionResult Index()
        {
            return View();
        }

        [Authorize]
        [HttpGet]
        public IActionResult AddItem()
        {
            if (User.Identity.Name != null)
            {
                var currency = _userRepository.UserCurrency(User.Identity.Name);
                ViewData["Currency"] = currency;
                ItemAddViewModel model = new ItemAddViewModel();
                model.Categories = _categoryRepository.GetAllCategoriesSelectedList();


                return View(model);
            }


            return View();
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> AddItem(ItemAddViewModel item)
        {
            var userName = User.Identity.Name;

            if (ModelState.IsValid)
            {
                item.UserName = userName;
                item.Status = Status.Added;

                await _repository.AddItem(item);
            }


            return View(item);
        }

        public IActionResult ViewItem(int itemId)
        {
            var item = _repository.GetItem(itemId);

            ItemViewModel model = null;


            if (item != null)
            {
                var buyerCurrency = _userRepository.UserCurrency(User.Identity.Name);
                var buyerCurrencyRate = _userRepository.UserCurrencyRate(User.Identity.Name);
                var sellerCurrency = _userRepository.UserCurrency(item.User.Email);
                string imgUrl = @"/images/no-image.png";

                if (item.ImgUrl != null)
                { imgUrl = item.ImgUrl; }

                if (buyerCurrency == sellerCurrency || buyerCurrency == null)
                {
                    model = new ItemViewModel()
                    {
                        ItemId = itemId,
                        ItemName = item.Name,
                        ItemDescription = item.Description,
                        SellerPrice = item.Price,
                        SellerCurrency = item.User.Country.Currency.ShortName,
                        ImgUrl = imgUrl
                    };
                }
                else
                {
                    model = new ItemViewModel()
                    {
                        ItemId = itemId,
                        ItemName = item.Name,
                        ItemDescription = item.Description,
                        SellerPrice = item.Price,
                        SellerCurrency = item.User.Country.Currency.ShortName,

                        BuyerCurrency = buyerCurrency,
                        BuyerPrice = item.Price * item.User.Country.Currency.Rate / buyerCurrencyRate,
                        ImgUrl = imgUrl
                    };

                }
            }
            else
            {
                ViewBag.nullItem = "No item with such id";
                return View();
            }

            return View(model);
        }

        [Authorize]
        public IActionResult ConfirmOrder(int itemId)
        {
            var item = _repository.GetItem(itemId);
            var buyerCurrencyRate = _userRepository.UserCurrencyRate(User.Identity.Name);

            ItemOrderModel model = new ItemOrderModel();

            if (item != null)
            {
                model = new ItemOrderModel()
                {
                    ItemName = item.Name,
                    Price = item.Price * item.User.Country.Currency.Rate / buyerCurrencyRate,
                    BuyerName = User.Identity.Name,
                    ItemId = itemId,
                    SellerName = item.User.Name,
                    PossibleToShipAnotherCountry = item.IsMultiCountryPossible,
                };
            }

            return View(model);
        }

        [Authorize]
        public async Task<IActionResult> Buy(ItemOrderModel model)
        {
            var item = _repository.GetItem(model.ItemId);

            if (_orderRepository.PlaceOrder(model.ItemId, item.Price, model.BuyerName, model.Qty, model.Status))
            {
                var buyer = _userRepository.FindUserByName(model.BuyerName);
                var MessageForSeller = $"Buyer {buyer.Name} with email {buyer.Email} has purchased item {item.Name}. Please contact him";
                var MessageForBuyer = $"You have placed new order for item {item.Name} from {item.User.Name} whos email is {item.User.Email} In urgent cases you can email to seller";

                await _messageService.SendMessageAsync("email", MessageForSeller, "New order", item.User.Email); // message to seller
                await _messageService.SendMessageAsync("email", MessageForBuyer, "Order confirmation", buyer.Email); // message to buyer

                ViewBag.Status = "Order has been placed. Seller will contact you as soon as possible. Please check email";
            }
            else
            {
                ViewBag.Status = "Error";
            }

            return View();
        }


    }
}
