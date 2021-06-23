using Microsoft.AspNetCore.Mvc;
using Shop.Data.Interfaces;
using Shop.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Controllers
{
    public class HomeController:Controller
    {
        private readonly IAllItems _itemRep;
        public HomeController(IAllItems itemRep)
        {
            _itemRep = itemRep;
        }
        public ViewResult Index()
        {
            var homeItems = new HomeViewModel { FavoriteItems = _itemRep.GetFavoriteItems };
            return View(homeItems);
        }
    }
}
