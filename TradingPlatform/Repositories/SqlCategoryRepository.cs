using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TradingPlatform.Models;

namespace TradingPlatform.Repositories
{
    public class SqlCategoryRepository : ICategoryRepository
    {
        private TradingPlatformContext _context { get; set; }

        public SqlCategoryRepository(TradingPlatformContext context)
        {
            _context = context;
        }

        public List<SelectListItem> GetAllCategoriesSelectedList()
        {
            var allCountriesSelectListType = _context.Categories.Select(s => new SelectListItem { Value = s.Id.ToString(), Text = s.Name }).ToList();

            return allCountriesSelectListType;
        }

        public IEnumerable<Category> GetAllCategories()
        {
            var allCategories = _context.Categories.ToList();

            return allCategories;
        }

        public string GetCategoryName(int categoryId)
        {
            string categoryName = _context.Categories.FirstOrDefault(t => t.Id == categoryId).Name;

            return categoryName;
        }

    }
}
