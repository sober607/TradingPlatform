using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TradingPlatform.Models;

namespace TradingPlatform.Repositories
{
    public interface ICountriesRepository
    {
        public List<Country> GetAllCountries();

        public Country FindCountryByName(string countryName);
    }
}
