using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace GenSoftDemoApp.Entity.Entities
{
    public class OrderDetail:EntityBase
    {
        public int ProductId { get; set; }
        public Product Product { get; set; } = null!;
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public int OrderId { get; set; } 
    }
}
