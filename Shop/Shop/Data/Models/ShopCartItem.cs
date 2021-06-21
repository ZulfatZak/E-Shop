using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Data.Models
{
    public class ShopCartItem
    {
        public int Id { get; set; }
        public Item Item { get; set; }
        public uint Price { get; set; }
        public string ShopCartId { get; set; }
    }
}
