using Shop.Data.Interfaces;
using Shop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Data.Mocks
{
    public class MockCategory : IItemsCategory
    {
        public IEnumerable<Category> AllCategories => new List<Category>
            {
                new Category{
                    CategoryName="Ноутбуки", 
                    Description=""},
                new Category{
                    CategoryName="Смартфоны", 
                    Description=""},
                new Category{
                    CategoryName="Телевизоры", 
                    Description=""},
                new Category{
                    CategoryName="Оргтехника", 
                    Description=""}
            };
    }
}
