using GenSoftDemoApp.Dto.Enums;
using GenSoftDemoApp.Dto.OrderDetailDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenSoftDemoApp.Dto.OrderDtos
{
    public class OrderDto
    {
        public int Id { get; set; }
        public string OrderNumber { get; set; } = null!;
        public DateTime OrderDate { get; set; }
        public decimal TotalPrice { get; set; }
        public int UserId { get; set; }
        public OrderStatus Status { get; set; } = OrderStatus.Received;
        public List<OrderDetailDto>? OrderDetails { get; set; }
        public string? IpAddress { get; set; }
        public string? FullName { get; set; }
        public string? CompanyName { get; set; }
        public string? Province { get; set; }
        public string? City { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Address { get; set; }
        public string? Mail { get; set; }
        public string? Notes { get; set; }
    }
}
