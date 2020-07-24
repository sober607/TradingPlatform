using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TradingPlatform.Infrastructure.BackgroundServices.Interfaces;
using TradingPlatform.Infrastructure.Configuration;

namespace TradingPlatform.Infrastructure.BackgroundServices.Implementations
{
    public class SyncCurrencyRateBackgroundService : BackgroundService
    {
        private IServiceScopeFactory _scopeFactory { get; }

        public IConfiguration _configuration { get; set; }

        public TradingPlatformConfiguration _options { get; set; }

        public SyncCurrencyRateBackgroundService(IServiceScopeFactory scopeFactory, IConfiguration configuration, IOptions<TradingPlatformConfiguration> options)
        {
            _scopeFactory = scopeFactory;
            _configuration = configuration;
            _options = options.Value;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                using (var scope = _scopeFactory.CreateScope())
                {
                    var context = scope.ServiceProvider.GetService<ISynchroniseCurrencyRate>();

                    context.UpdateCurrencyRate();

                    Console.WriteLine("Sync Done");
                    await Task.Delay(TimeSpan.FromHours(_options.SyncCurrencyRateFrequencyHours));

                }
            }
        }
    }
}
