﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GemSoftDemoApp.Dto.BrandDtos
{
    public class BrandDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public DateTime CreatedDate { get; set; }
    }
}
