using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Shop.Data;
using Shop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElShop.Data
{
    public class DBObjects
    {
        public static void Initial(AppDBContent content)
        {
            
            

            if(!content.Category.Any())
            {
                content.Category.AddRange(Categories.Select(c =>c.Value));
            }

            if (!content.Item.Any())
            {
                content.AddRange(
                    new Item
                    {
                        Name = "Huawei MateBook 14",
                        ShortDescription = "Ноутбук",
                        LongDescription = "i7-1165G7 16 ГБ + 512 ГБ",
                        Image = "/img/Huawei_MateBook_D_14_3.jpg",
                        Price = 50799,
                        IsFavorite = true,
                        Available = true,
                        Category = Categories["Ноутбуки"]
                    },
                    new Item
                    {
                        Name = "Asus ExpertBook P1",
                        ShortDescription = "Ноутбук",
                        LongDescription = "i5 8 ГБ + 512 ГБ",
                        Image = "/img/Asus_ExpertBook_P1.jpg",
                        Price = 45499,
                        IsFavorite = true,
                        Available = true,
                        Category = Categories["Ноутбуки"]
                    },
                    new Item
                    {
                        Name = "Iphone SE",
                        ShortDescription = "Смартфон",
                        LongDescription = "128 ГБ, белый (новая комплектация",
                        Image = "/img/Iphone_SE.jpg",
                        Price = 36100,
                        IsFavorite = true,
                        Available = true,
                        Category = Categories["Смартфоны"]
                    },
                    new Item
                    {
                        Name = "Xiaomi Redmi 9A",
                        ShortDescription = "Смартфон",
                        LongDescription = "32/3 гб, синий",
                        Image = "/img/Xiaomi_Redmi_9A.jpg",
                        Price = 11999,
                        IsFavorite = true,
                        Available = true,
                        Category = Categories["Смартфоны"]
                    },
                    new Item
                    {
                        Name = "Xiaomi Mi TV 4S",
                        ShortDescription = "Телевизор",
                        LongDescription = "50' T2 Global (2018) Стальной",
                        Image = "/img/Xiaomi_Mi_TV_4S.jpg",
                        Price = 34990,
                        IsFavorite = true,
                        Available = true,
                        Category = Categories["Телевизоры"]
                    },
                    new Item
                    {
                        Name = "LG 55'",
                        ShortDescription = "Телевизор",
                        LongDescription = "43UK6200PLA, Smart TV",
                        Image = "/img/LG_55.jpg",
                        Price = 25590,
                        IsFavorite = true,
                        Available = true,
                        Category = Categories["Телевизоры"]
                    },
                    new Item
                    {
                        Name = "Принтер HP M607",
                        ShortDescription = "Оргтехника",
                        LongDescription = "",
                        Image = "/img/HP_M607.jpg",
                        Price = 60000,
                        IsFavorite = true,
                        Available = true,
                        Category = Categories["Оргтехника"]
                    },
                    new Item
                    {
                        Name = "Kyocera M2040dn",
                        ShortDescription = "Оргтехника",
                        LongDescription = "",
                        Image = "/img/Kyocera_M2040dn.jpg",
                        Price = 37500,
                        IsFavorite = true,
                        Available = true,
                        Category = Categories["Оргтехника"]
                    }
                    );
            }
            content.SaveChanges();
        }
        private static Dictionary<string, Category> category;
        public static Dictionary<string, Category> Categories
        {
            get
            {
                if(category==null)
                {
                    var list = new Category[]
                    {
                        new Category{CategoryName="Ноутбуки",Description=""},
                        new Category{CategoryName="Смартфоны",Description=""},
                        new Category{CategoryName="Телевизоры",Description=""},
                        new Category{CategoryName="Оргтехника",Description=""}
                    };
                    category = new Dictionary<string, Category>();
                    foreach (Category el in list)
                    {
                        category.Add(el.CategoryName, el);
                    }
                }
                return category;
            }
        }
    }
}
