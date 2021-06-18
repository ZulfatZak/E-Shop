using Shop.Data.Interfaces;
using Shop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Data.Mocks
{
    public class MockItems : IAllItems
    {
        private readonly IItemsCategory _categoryItems = new MockCategory();
        public IEnumerable<Item> Items => new List<Item>
                {
                    new Item{
                        Name="Huawei MateBook 14", 
                        ShortDescription="Ноутбук",
                        LongDescription="i7-1165G7 16 ГБ + 512 ГБ", 
                        Image="",
                        Price=50799,
                        IsFavorite=true,
                        Available=true, 
                        Category=_categoryItems.AllCategories.ElementAt(0)},
                    new Item{
                        Name="Asus ExpertBook P1", 
                        ShortDescription="Ноутбук",
                        LongDescription="i5 8 ГБ + 512 ГБ",
                        Image="",
                        Price=45499,
                        IsFavorite=true,
                        Available=true,
                        Category=_categoryItems.AllCategories.ElementAt(0)},
                    new Item{
                        Name="Iphone SE", 
                        ShortDescription="Смартфон",
                        LongDescription="",
                        Image="128 ГБ, белый (новая комплектация",
                        Price=36100,
                        IsFavorite=true,
                        Available=true,
                        Category=_categoryItems.AllCategories.ElementAt(1)},
                    new Item{
                        Name="Xiaomi Redmi 9A", 
                        ShortDescription="Смартфон",
                        LongDescription="32/3 гб, синий",
                        Image="",
                        Price=11999,
                        IsFavorite=true,
                        Available=true,
                        Category=_categoryItems.AllCategories.ElementAt(1)},
                    new Item{
                        Name="Xiaomi Mi TV 4S", 
                        ShortDescription="Телевизор",
                        LongDescription="50' T2 Global (2018) Стальной",
                        Image="",
                        Price=34990,
                        IsFavorite=true,
                        Available=true,
                        Category=_categoryItems.AllCategories.ElementAt(2)},
                    new Item{
                        Name="LG 55'", 
                        ShortDescription="Телевизор",
                        LongDescription="43UK6200PLA, Smart TV",
                        Image="",
                        Price=25590,
                        IsFavorite=true,
                        Available=true,
                        Category=_categoryItems.AllCategories.ElementAt(2)},
                    new Item{
                        Name="Принтер HP M607", 
                        ShortDescription="Оргтехника",
                        LongDescription="",
                        Image="",
                        Price=1000,
                        IsFavorite=true,
                        Available=true,
                        Category=_categoryItems.AllCategories.ElementAt(3)},
                    new Item{
                        Name="Kyocera M2040dn", 
                        ShortDescription="Оргтехника",
                        LongDescription="",
                        Image="",
                        Price=1000,
                        IsFavorite=true,
                        Available=true,
                        Category=_categoryItems.AllCategories.ElementAt(3)}
                };
        public IEnumerable<Item> GetFavoriteItems { get; set; }

        public Item GetObjectItem(int carId)
        {
            throw new NotImplementedException();
        }
    }
}
