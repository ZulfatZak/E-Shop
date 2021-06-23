using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Data.Models
{
    public class OrderDetail
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int CarId { get; set; }
        public uint Price { get; set; }
        public virtual Item Item { get; set; }
        public virtual Order Order { get; set; }
    }
}
