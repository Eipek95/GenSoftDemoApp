namespace GenSoftDemoApp.UI.ViewModels.OrderViewModels
{
    public class CreateOrderViewModel
    {
        public decimal TotalPrice { get; set; }
        public int UserId {  get; set; }
        public List<CreateOrderDetailViewModel>? OrderDetails { get; set; }
        public string? FullName { get; set; }
        public string? CompanyName { get; set; }
        public string? Province { get; set; }
        public string? City { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Address { get; set; }
        public string? Mail { get; set; }
        public string? Notes { get; set; }
        public string? IpAddress { get; set; }

    }
}
