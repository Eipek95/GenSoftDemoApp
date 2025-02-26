using GemSoftDemoApp.Dto.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GemSoftDemoApp.Entity.Entities
{
    public class Order: EntityBase
    {
        public DateTime OrderDate { get; set; }
        public decimal TotalPrice { get; set; }
        public int UserId{ get; set; }
        public AppUser? User{ get; set; }
        public List<OrderDetail>? OrderDetails { get; set; }
        public OrderStatus Status { get; set; } = OrderStatus.Received;
        public string OrderNumber { get; set; } = null!;
    }
}
