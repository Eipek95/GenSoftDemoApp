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
        public int CategoryId { get; set; }
        public CategoryDto? Category { get; set; }
    }
}
