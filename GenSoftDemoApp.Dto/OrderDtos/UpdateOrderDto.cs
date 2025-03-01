using GenSoftDemoApp.Dto.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenSoftDemoApp.Dto.OrderDtos
{
    public class UpdateOrderDto
    {
        public int Id { get; set; }
        public OrderStatus Status { get; set; } = OrderStatus.Received;
    }
}
