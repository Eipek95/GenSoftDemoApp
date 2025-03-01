using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenSoftDemoApp.Entity.Entities
{
    public class AppUser:IdentityUser<int>
    {
        public List<Order>? Orders { get; set; }
    }
}
