using GenSoftDemoApp.DataAccess.Abstract;
using GenSoftDemoApp.DataAccess.Context;
using GenSoftDemoApp.Entity.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenSoftDemoApp.DataAccess.Concrete
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<List<Category>> GetAllCategoryWithProducts()
        {
            List<Category> categories =await _context.Categories.AsNoTracking().Include(c => c.Products).ToListAsync();
            return categories;
        }
    }
}
