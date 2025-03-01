using GenSoftDemoApp.Dto.BrandDtos;
using GenSoftDemoApp.Dto.CategoryDtos;
using System.Text.Json.Serialization;

namespace GenSoftDemoApp.Dto.ProductDtos
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public decimal Price { get; set; }
        public string? ImageUrl { get; set; }
        public int BrandId { get; set; }
        [JsonIgnore]
        public BrandDto? Brand { get; set; }
        public int CategoryId { get; set; }
        [JsonIgnore]
        public CategoryDto? Category { get; set; }
    }
}
