using Microsoft.AspNetCore.Mvc;
using Shop.Data.Interfaces;
using Shop.Data.Models;
using Shop.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Controllers
{
    public class ItemsController:Controller
    {
        private readonly IAllItems _allItems;
        private readonly IItemsCategory _allCategory;

        public ItemsController(IAllItems iAllItems, IItemsCategory iItemsCategory)
        {
            _allItems = iAllItems;
            _allCategory = iItemsCategory;
        }
        [Route("Items/List")]
        [Route("Items/List/{category}")]
        public ViewResult List(string category)
        {
            string _category = category;
            IEnumerable<Item> items = null;
            string currCategory = "";
            if(string.IsNullOrEmpty(category))
            {
                items = _allItems.Items.OrderBy(i => i.Id);
            }
            else
            {
                if(string.Equals("notebook",category, StringComparison.OrdinalIgnoreCase)) //игнорируем регистр
                {
                    items = _allItems.Items.Where(i => i.Category.CategoryName.Equals("Ноутбуки"));
                    currCategory = "Ноутбуки";
                }    
                else if (string.Equals("smartphone", category, StringComparison.OrdinalIgnoreCase)) //игнорируем регистр
                {
                    items = _allItems.Items.Where(i => i.Category.CategoryName.Equals("Смартфоны"));
                    currCategory = "Смартфоны";
                }
                else if (string.Equals("tv", category, StringComparison.OrdinalIgnoreCase)) //игнорируем регистр
                {
                    items = _allItems.Items.Where(i => i.Category.CategoryName.Equals("Телевизоры"));
                    currCategory = "Телевизоры";
                }
                else if (string.Equals("printers", category, StringComparison.OrdinalIgnoreCase)) //игнорируем регистр
                {
                    items = _allItems.Items.Where(i => i.Category.CategoryName.Equals("Оргтехника"));
                    currCategory = "Оргтехника";
                }
                
            }
            var itemObj = new ItemsListViewModel
            {
                AllItems = items,
                CurrCategory = currCategory
            };

            ViewBag.Title = "Страница с техникой";
            
            return View(itemObj);
        }
    }
}
