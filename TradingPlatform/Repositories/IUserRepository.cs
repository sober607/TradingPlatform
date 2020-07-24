using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TradingPlatform.Models;

namespace TradingPlatform.Repositories
{
    public interface IUserRepository
    {
        public string UserCurrency(string username);

        public decimal UserCurrencyRate(string username);

        public User FindUserByName(string username);
    }
}
