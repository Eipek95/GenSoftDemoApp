using GenSoftDemoApp.Dto.ProductDtos;
using System.Text.Json.Serialization;

namespace GenSoftDemoApp.Dto.OrderDetailDtos
{
    public class OrderDetailDto
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        [JsonIgnore]
        public int OrderId { get; set; }
        public ProductDto? Product{ get; set; }
    }
}
