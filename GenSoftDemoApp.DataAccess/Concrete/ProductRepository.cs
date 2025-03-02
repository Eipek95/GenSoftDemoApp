using GenSoftDemoApp.DataAccess.Abstract;
using GenSoftDemoApp.DataAccess.Context;
using GenSoftDemoApp.Entity.Entities;
using Microsoft.EntityFrameworkCore;

namespace GenSoftDemoApp.DataAccess.Concrete
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(AppDbContext context) : base(context)
        {
        }



        public async Task<List<Product>> GetAllProductByCategoryId(int categoryId)
        {
            var products = await _context.Products.Where(p => p.CategoryId == categoryId).AsNoTracking()
                .Include(p => p.Category)
                .ToListAsync();
            if (!products.Any())
                return new List<Product>();
            return products;
        }

        public async Task<List<Product>> GetAllProductWithCategory()
        {
            var products = await _context.Products.AsNoTracking()
            .Include(p => p.Category)
            .ToListAsync();
            if (!products.Any())
                return new List<Product>();
            return products;
        }
    }
}
