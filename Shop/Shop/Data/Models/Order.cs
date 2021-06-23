using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Data.Models
{
    public class Order
    {
        [BindNever]
        public int Id { get; set; }

        [Display(Name="Введите имя")]
        [StringLength(25)]
        [Required(ErrorMessage ="Длина имени не менее 3 символов")]
        public string Name { get; set; }

        [Display(Name = "Фамилия")]
        [StringLength(25)]
        [Required(ErrorMessage = "Длина фамилии не менее 3 символов")]
        public string Surname { get; set; }

        [Display(Name = "Адресс")]
        [StringLength(25)]
        [Required(ErrorMessage = "Длина адреса не менее 3 символов")]
        public string Adress { get; set; }

        [Display(Name = "Телефон")]
        [DataType(DataType.PhoneNumber)]
        [StringLength(11)]
        [Required(ErrorMessage = "Длина имени не менее 10 знаков")]
        public string Phone { get; set; }

        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        [StringLength(10)]
        [Required(ErrorMessage = "Длина почты не менее 3 символов")]
        public string Email { get; set; }
        [BindNever]
        [ScaffoldColumn(false)]
        public DateTime OrderTime { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }
    }
}
