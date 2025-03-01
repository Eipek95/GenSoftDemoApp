using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenSoftDemoApp.Entity.Entities
{
    public class Product:EntityBase
    {
        public decimal Price { get; set; }
        public string? ImageUrl{ get; set; }
        public int BrandId { get; set; }
        public Brand? Brand { get; set; }
        public int CategoryId { get; set; }
        public Category? Category { get; set; }
    }
}
