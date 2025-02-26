﻿using GemSoftDemoApp.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GemSoftDemoApp.DataAccess.Abstract
{
    public interface IProductRepository:IRepository<Product>
    {
        Task<List<Product>> GetAllProductByBrandId(int brandId);
    }
}
