using GenSoftDemoApp.DataAccess.Abstract;
using GenSoftDemoApp.DataAccess.Context;
using GenSoftDemoApp.Entity.Entities;

namespace GenSoftDemoApp.DataAccess.Concrete
{
    public class BrandRepository : GenericRepository<Brand>, IBrandRepository
    {
        public BrandRepository(AppDbContext context) : base(context)
        {
        }
    }
}
