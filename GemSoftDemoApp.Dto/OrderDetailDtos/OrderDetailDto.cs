using GemSoftDemoApp.Dto.OrderDtos;
using GemSoftDemoApp.Dto.ProductDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace GemSoftDemoApp.Dto.OrderDetailDtos
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
