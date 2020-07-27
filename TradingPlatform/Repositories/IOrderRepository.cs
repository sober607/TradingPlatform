using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TradingPlatform.Models;

namespace TradingPlatform.Repositories
{
    public interface IOrderRepository
    {
        public bool PlaceOrder(int itemId, decimal Price, string buyerName, int qty, string status);

        public List<Order> GetUsersPurchasesList(User user); // To see what purchased exact user

        /*public List<Order> Get*/ // To see list of orders to sellers items.
    }
}
