using GemSoftDemoApp.DataAccess.Abstract;
using GemSoftDemoApp.DataAccess.Context;
using GemSoftDemoApp.Entity.Entities;
using Microsoft.EntityFrameworkCore;

namespace GemSoftDemoApp.DataAccess.Concrete
{
    public class BrandRepository : GenericRepository<Brand>, IBrandRepository
    {
        public BrandRepository(AppDbContext context) : base(context)
        {
        }
    }
}
