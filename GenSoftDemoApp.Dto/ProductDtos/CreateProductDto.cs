using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenSoftDemoApp.Dto.ProductDtos
{
    public class CreateProductDto
    {
        public string Title { get; set; } = null!;
        public decimal Price { get; set; }
        public string? ImageUrl { get; set; }
        public int BrandId { get; set; }
        public int CategoryId { get; set; }
    }
}
