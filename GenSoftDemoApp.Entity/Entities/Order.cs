using GenSoftDemoApp.Dto.Enums;

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
    }
}
