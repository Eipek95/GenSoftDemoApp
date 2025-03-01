using GemSoftDemoApp.DataAccess.Abstract;
using GemSoftDemoApp.DataAccess.Context;
using GemSoftDemoApp.Entity.Entities;
using Microsoft.EntityFrameworkCore;

namespace GemSoftDemoApp.DataAccess.Concrete
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<List<Product>> GetAllProductByBrandId(int brandId)
        {
            var products = await _context.Products.Where(p => p.BrandId == brandId).AsNoTracking()
                .Include(p=>p.Brand)
                .Include(p=>p.Category)
                .ToListAsync();
            if (!products.Any())
                return new List<Product>();
            return products;
        }

        public async Task<List<Product>> GetAllProductByCategoryId(int categoryId)
        {
            var products = await _context.Products.Where(p => p.CategoryId == categoryId).AsNoTracking()
                .Include(p => p.Brand)
                .Include(p => p.Category)
                .ToListAsync();
            if (!products.Any())
                return new List<Product>();
            return products;
        }
    }
}
