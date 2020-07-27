using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TradingPlatform.Repositories;
using TradingPlatform.ViewModels;

namespace TradingPlatform.Controllers
{
    public class OrderController : Controller
    {
        private IOrderRepository _ordersRepository;

        private IUserRepository _usersRepository;

        public OrderController (IOrderRepository ordersRepository, IUserRepository usersRepository)
        {
            _ordersRepository = ordersRepository;
            _usersRepository = usersRepository;
        }

        [Authorize]
        public IActionResult MyOrders()
        {
            var userName = User.Identity.Name;
            ViewBag.OrdersList = new List<BuyerOrderListViewModel>();

            if (User.Identity.IsAuthenticated)
            {    
                var user = _usersRepository.FindUserByName(userName);
                var ordersList = _ordersRepository.GetUsersPurchasesList(user);
                var tempOrdersList = (user != null && ordersList != null) ? ordersList : null;
                

                if (tempOrdersList != null)
                {
                    foreach (var item in tempOrdersList)
                    {
                        ViewBag.OrdersList.Add(new BuyerOrderListViewModel() { 
                            ItemName = item.ItemName, 
                            CurrencyName = item.User.Country.Currency.ShortName, 
                            OrderDate = item.DateTime, 
                            OrderId=item.Id, 
                            Price = item.Price, 
                            SellerEmail = item.Item.User.Email,
                            SellerName = item.Item.User.Name,
                            Status = item.Status,
                            TrackingNumber = item.TrackingNumber
                        });
                    }
                }
                else
                {
                    ViewBag.OrdersList = null;
                }
            }

                return View();
        }

        //[Authorize]
        //public IActionResult CustomerOrders()
        //{
        //    var user = User.Identity.Name;
        //    var listOFBuyersPurvchased items = ;
        //    List<SellerItemsOrderListViewModel> orders = new List<SellerItemsOrderListViewModel>;

        //    if (User.Identity.IsAuthenticated)
        //    {

        //    }
        //}
    }
}
