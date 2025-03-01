using GenSoftDemoApp.Dto.ProductDtos;

namespace GenSoftDemoApp.Dto.CategoryDtos
{
    public class CategoryDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public List<ProductDto>? Products { get; set; }

    }
}
