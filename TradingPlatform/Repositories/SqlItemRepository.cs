﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TradingPlatform.Infrastructure.Services.Interfaces;
using TradingPlatform.Models;
using TradingPlatform.ViewModels;

namespace TradingPlatform.Repositories
{
    public class SqlItemRepository : IItemRepository
    {
        public IFileService _fileService { get; set; }

        private TradingPlatformContext _context { get; set; }

        private readonly IHttpContextAccessor _httpContextAccessor;

        private IUserRepository _userRepository { get; set; }

        public SqlItemRepository(IFileService fileService, TradingPlatformContext context, IHttpContextAccessor httpContextAccessor, IUserRepository userRepository)
        {
            _fileService = fileService;
            _context = context;
            _httpContextAccessor = httpContextAccessor;
            _userRepository = userRepository;
        }

        public async Task AddItem(ItemAddViewModel item)
        {
            User user = _context.Users.FirstOrDefault(t => t.UserName == item.UserName);

            Item newItem = new Item()
            {
                Name = item.Name,
                Description = item.Description,
                ImgUrl = await _fileService.UploadImageAsync(item.File),
                Price = item.Price,
                User = (user != null) ? user : null,
                IsService = item.IsService,
                Category = _context.Categories.FirstOrDefault(t => t.Id == item.CategoryId),
                IsMultiCountryPossible = item.IsMultiCountryPossible
            };

            _context.Items.Add(newItem);
            _context.SaveChanges();

        }

        public IEnumerable<Item> GetCategorisedItems(int categoryId)
        {
            var itemsList = _context.Items.Where(t => t.CategoryId == categoryId).ToList();

            return itemsList;
        }

        public IEnumerable<Item> GetAllItems()
        {
            var itemsList = _context.Items;

            return itemsList;
        }

        public Item GetItem(int itemId)
        {
            var item = _context.Items.FirstOrDefault(t => t.Id == itemId);

            return item;
        }

        public IEnumerable<ItemListViewModel> GetItemsListForApi(int? categoryId)
        {
            var originalItemsList = _context.Items.ToList();
            var newList = new List<ItemListViewModel>();

            if (categoryId == 0 || categoryId == null)
            {
                foreach (Item t in originalItemsList)
                {
                    var imgUrl = $"{ _httpContextAccessor.HttpContext.Request.Scheme }://{_httpContextAccessor.HttpContext.Request.Host}";

                    var newItem = new ItemListViewModel()
                    {
                        ItemId = t.Id,
                        ItemName = t.Name,
                        Price = t.Price,
                        Currency = t.User.Country.Currency.ShortName,
                        ImgUrl = (t.ImgUrl != null) ? (imgUrl + t.ImgUrl) : null
                    };

                    newList.Add(newItem);
                }

                return newList;
            }
            else
            {
                foreach (Item t in originalItemsList.Where(t => t.CategoryId == categoryId))
                {
                    var newItem = new ItemListViewModel()
                    {
                        ItemName = t.Name,
                        Price = t.Price,
                        Currency = t.User.Country.Currency.ShortName
                    };

                    newList.Add(newItem);
                }

                return newList;
            }

        }

        public List<ItemListViewModel> GetRandomItems(int qty)
        {
            int itemsQty = _context.Items.Count();
            List<ItemListViewModel> itemsList = new List<ItemListViewModel>();

            if (itemsQty <1)
            {
                return null;
            }
            else if (itemsQty < qty)
            {
                qty = itemsQty;
            }

            var items = _context.Items.OrderBy(r => Guid.NewGuid()).Take(qty).ToList();

            foreach(var t in items)
            {
                var temporaryItemInItemsListViewModel = new ItemListViewModel() { ItemName = t.Name, Price = t.Price, Currency = t.User.Country.Currency.ShortName, ImgUrl = t.ImgUrl, ItemId = t.Id };
                itemsList.Add(temporaryItemInItemsListViewModel);
            }
            return itemsList;
        }

        public IEnumerable<Item> GetUserItems(string username)
        {
            var user = _userRepository.FindUserByName(username);
            var userItems = user.Items;

            if (user!=null && userItems!=null)
            {
                return userItems;
            }
            return null;
        }
    }
}
