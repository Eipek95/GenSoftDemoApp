using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GemSoftDemoApp.Entity.Entities
{
    public class Brand:EntityBase
    {
        public List<Product>? Products { get; set; }
    }
}
