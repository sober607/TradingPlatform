using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TradingPlatform.Repositories;
using TradingPlatform.ViewModels;

namespace TradingPlatform.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataController : ControllerBase
    {
        public IItemRepository _itemRepository { get; set; }

        public DataController(IItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }

        public IEnumerable<ItemListViewModel> ItemsList([FromQuery] int categoryId)
        {
            var itemsList = _itemRepository.GetItemsListForApi(categoryId);

            return itemsList;
        }

    }
}
