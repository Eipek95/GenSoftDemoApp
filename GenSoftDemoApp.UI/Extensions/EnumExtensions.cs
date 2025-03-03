using GenSoftDemoApp.UI.Enums;

namespace GenSoftDemoApp.UI.Extensions
{
    public static class EnumExtensions
    {
        public static string GetDisplayName(this OrderStatus status)
        {
            return status switch
            {
                OrderStatus.Received => "Sipariş Alındı",
                OrderStatus.Preparing => "Hazırlanıyor",
                OrderStatus.Shipped => "Kargoya Verildi",
                OrderStatus.Cancelled => "İptal Edildi",
                OrderStatus.Delivered => "Teslim Edildi",
                _ => status.ToString()
            };
        }
    }
}
