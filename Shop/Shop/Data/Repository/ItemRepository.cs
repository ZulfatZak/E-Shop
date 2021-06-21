using Microsoft.EntityFrameworkCore;
using Shop.Data.Interfaces;
using Shop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Data.Repository 
{
    public class ItemRepository : IAllItems
    {
        private readonly AppDBContent appDBContent;
        public ItemRepository(AppDBContent appDBContent)
        {
            this.appDBContent = appDBContent;
        }
        public IEnumerable<Item> Items => appDBContent.Item.Include(c => c.Category);

        public IEnumerable<Item> GetFavoriteItems => appDBContent.Item.Where(p => p.IsFavorite).Include(c => c.Category);

        public Item GetObjectItem(int itemId) => appDBContent.Item.FirstOrDefault(p => p.Id == itemId);
    }
}
