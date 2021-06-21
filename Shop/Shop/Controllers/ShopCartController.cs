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
    public class ShopCartController:Controller
    {
        private readonly IAllItems _itemRep;
        private readonly ShopCart _shopCart;
        public ShopCartController(IAllItems itemRep, ShopCart shopCart)
        {
            _itemRep = itemRep;
            _shopCart = shopCart;
        }
        public ViewResult Index()
        {
            var items = _shopCart.GetShopItems();
            _shopCart.ListShopItems= items;
            var obj = new ShopCartViewModel
            {
                ShopCart = _shopCart
            };
            return View(obj);
        }
        public RedirectToActionResult AddToCart(int id)
        {
            var item = _itemRep.Items.FirstOrDefault(i => i.Id==id);
            if(item!=null)
            {
                _shopCart.AddToCart(item);
            }
            return RedirectToAction("Index");
        }
    }
}
