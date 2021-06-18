using Shop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Data.Interfaces
{
    public interface IAllItems
    {
        IEnumerable<Item> Items { get; }
        IEnumerable<Item> GetFavoriteItems { get; set; }
        Item GetObjectItem(int carId);
    }
}
