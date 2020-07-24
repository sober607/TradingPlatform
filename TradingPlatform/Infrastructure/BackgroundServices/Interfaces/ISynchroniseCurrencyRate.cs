using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TradingPlatform.Infrastructure.BackgroundServices.Interfaces
{
    public interface ISynchroniseCurrencyRate
    {
        public void UpdateCurrencyRate();
    }
}
