using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenSoftDemoApp.Dto.BrandDtos
{
    public class UpdateBrandDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
    }
}
