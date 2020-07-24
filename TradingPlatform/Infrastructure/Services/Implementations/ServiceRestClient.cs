using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TradingPlatform.Infrastructure.Configuration;
using TradingPlatform.Infrastructure.Services.Assistant;
using TradingPlatform.Infrastructure.Services.Interfaces;

namespace TradingPlatform.Infrastructure.Services.Implementations
{
    public class ServiceRestClient : IServiceRestClient
    {
        public IConfiguration _configuration { get; set; }

        public TradingPlatformConfiguration _options { get; set; }

        public ServiceRestClient(IConfiguration configuration, IOptions<TradingPlatformConfiguration> options)
        {
            _configuration = configuration;
            _options = options.Value;
        }

        public CurrencyTempRoot GetCurrencyRate()
        {
            var client = new RestClient(_options.CurrencyApi.ApiHost);
            var request = new RestRequest(@_options.CurrencyApi.ApiUrl, Method.GET);
            IRestResponse response = client.Execute(request);

            CurrencyTempRoot currencyRateData = Newtonsoft.Json.JsonConvert.DeserializeObject<CurrencyTempRoot>(response.Content);

            if ((int)response.StatusCode != 200)
            {
                currencyRateData = null;
            }

            return currencyRateData;
        }
    }
}
