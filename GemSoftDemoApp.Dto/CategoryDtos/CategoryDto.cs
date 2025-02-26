using GemSoftDemoApp.Dto.ProductDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GemSoftDemoApp.Dto.CategoryDtos
{
    public class CategoryDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public DateTime CreatedDate { get; set; }

    }
}
