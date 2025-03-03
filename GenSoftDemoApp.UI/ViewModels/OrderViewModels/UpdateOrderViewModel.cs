using GenSoftDemoApp.UI.Enums;

namespace GenSoftDemoApp.UI.ViewModels.OrderViewModels
{
    public class UpdateOrderViewModel
    {
        public int Id { get; set; }
        public OrderStatus Status { get; set; } = OrderStatus.Received;
    }
}
