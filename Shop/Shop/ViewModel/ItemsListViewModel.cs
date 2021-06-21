using Shop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.ViewModel
{
    public class ItemsListViewModel
    {
        public IEnumerable<Item> AllItems { get; set; }
        public string CurrCategory { get; set; }
    }
}
