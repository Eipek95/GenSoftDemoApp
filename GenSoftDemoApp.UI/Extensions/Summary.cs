using GenSoftDemoApp.UI.Models;
using GenSoftDemoApp.UI.ViewModels.OrderViewModels;
using GenSoftDemoApp.UI.ViewModels.ProductViewModels;

namespace GenSoftDemoApp.UI.Extensions
{
    public static class Summary
    {
        public static List<OrderSummaryViewModel> GetProductOrderSummary(List<OrderViewModel> orders, List<ProductViewModel> allProducts)
        {
            var productOrderSummary = new Dictionary<string, int>();

            // Sipariş edilen ürünlerin miktarlarını toplama
            foreach (var order in orders)
            {
                if (order.OrderDetails != null)
                {
                    foreach (var orderDetail in order.OrderDetails)
                    {
                        var productName = orderDetail.Product?.Title;

                        if (productName != null)
                        {
                            if (productOrderSummary.ContainsKey(productName))
                            {
                                productOrderSummary[productName] += orderDetail.Quantity;
                            }
                            else
                            {
                                productOrderSummary[productName] = orderDetail.Quantity;
                            }
                        }
                    }
                }
            }

            // Tüm ürünleri gözden geçirme ve sipariş edilmemiş olanlar için sıfır ekleme
            foreach (var product in allProducts)
            {
                if (!productOrderSummary.ContainsKey(product.Title))
                {
                    productOrderSummary[product.Title] = 0;  // Sipariş edilmemiş ürünlerin miktarını sıfırla
                }
            }

            // Sonuçları listeye dönüştürme
            return productOrderSummary.Select(p => new OrderSummaryViewModel
            {
                ProductName = p.Key,
                TotalQuantity = p.Value
            }).ToList();
        }

    }
}
