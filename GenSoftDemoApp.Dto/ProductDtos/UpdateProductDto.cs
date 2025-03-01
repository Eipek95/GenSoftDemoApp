using GemSoftDemoApp.Dto.BrandDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GemSoftDemoApp.Dto.ProductDtos
{
    public class UpdateProductDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public decimal Price { get; set; }
        public string? ImageUrl { get; set; }
        public int BrandId { get; set; }
        public int CategoryId { get; set; }
    }
}
