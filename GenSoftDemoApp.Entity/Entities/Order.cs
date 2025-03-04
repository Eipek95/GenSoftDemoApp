﻿using GenSoftDemoApp.Dto.Enums;

namespace GenSoftDemoApp.Entity.Entities
{
    public class Order: EntityBase
    {
        public DateTime OrderDate { get; set; }
        public decimal TotalPrice { get; set; }
        public int UserId{ get; set; }
        public AppUser? User{ get; set; }
        public List<OrderDetail> OrderDetails { get; set; } = new();
        public OrderStatus Status { get; set; } = OrderStatus.Received;
        public string OrderNumber { get; set; } = null!;
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
