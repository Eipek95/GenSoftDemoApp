using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace GemSoftDemoApp.Entity.Entities
{
    public class OrderDetail:EntityBase
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; } 
        public int OrderId { get; set; } 
        public Order? Order { get; set; } 
    }
}
