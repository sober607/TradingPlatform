using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TradingPlatform.Models;

namespace TradingPlatform.Repositories
{
    public class SqlOrderRepository : IOrderRepository
    {
        private TradingPlatformContext _context { get; set; }

        private IUserRepository _userRepository { get; set; }

        public SqlOrderRepository(TradingPlatformContext context)
        {
            _context = context;
        }

        public bool PlaceOrder(int itemId, decimal Price, string buyerName, int qty, string status)
        {
            var buyer = _context.Users.FirstOrDefault(t => t.UserName == buyerName.ToString());
            var item = _context.Items.FirstOrDefault(t => t.Id == itemId);
            var orderDateTime = DateTime.Now.ToString();

            if (buyer != null && item != null)
            {
                Order newOrder = new Order()
                {
                    ItemName = item.Name,
                    Item = item,
                    Price = Price,
                    Qty = qty,
                    Status = status,
                    User = buyer,
                    DateTime = orderDateTime
                };

                _context.Orders.Add(newOrder);
                _context.SaveChanges();

                return true;
            }

            return false;
        }

        public List<Order> GetUsersPurchasesList(User user)
        {
            if (user != null)
            {
                var ordersList = _context.Orders.Where(t => t.User == user).ToList();
                return ordersList;
            }
            else
            {
                return null;
            };
        }
    }
}
