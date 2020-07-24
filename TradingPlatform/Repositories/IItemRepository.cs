using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TradingPlatform.Models;
using TradingPlatform.ViewModels;

namespace TradingPlatform.Repositories
{
    public interface IItemRepository
    {
        public Task AddItem(ItemAddViewModel item);

        public IEnumerable<Item> GetCategorisedItems(int categoryId);

        public IEnumerable<Item> GetAllItems();

        public IEnumerable<ItemListViewModel> GetItemsListForApi(int? categoryId);

        public Item GetItem(int itemId);
    }
}
