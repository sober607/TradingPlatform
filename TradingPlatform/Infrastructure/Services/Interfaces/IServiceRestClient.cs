using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TradingPlatform.Infrastructure.Services.Assistant;

namespace TradingPlatform.Infrastructure.Services.Interfaces
{
    public interface IServiceRestClient
    {
        public CurrencyTempRoot GetCurrencyRate();
    }
}
