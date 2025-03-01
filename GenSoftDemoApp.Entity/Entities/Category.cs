using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenSoftDemoApp.Entity.Entities
{
    public class Category : EntityBase
    {
        public List<Product>? Products { get; set; }
    }
}
