using GenSoftDemoApp.UI.Enums;

namespace GenSoftDemoApp.UI.ViewModels.OrderViewModels
{
    public class OrderViewModel
    {
        public int Id { get; set; }
        public string OrderNumber { get; set; } = null!;
        public DateTime OrderDate { get; set; }
        public decimal TotalPrice { get; set; }
        public int UserId { get; set; }
        public OrderStatus Status { get; set; } = OrderStatus.Received;
        public List<OrderDetailViewModel>? OrderDetails { get; set; }
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
