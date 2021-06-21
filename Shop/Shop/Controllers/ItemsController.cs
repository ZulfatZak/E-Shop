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
        public ViewResult List()
        {
            ViewBag.Title = "Страница с техникой";
            ItemsListViewModel obj = new ItemsListViewModel
            {
                AllItems = _allItems.Items,
                CurrCategory = "Оборудования"
            };
            return View(obj);
        }
    }
}
