using GenSoftDemoApp.Entity.Entities;

namespace GenSoftDemoApp.DataAccess.Abstract
{
    public interface ICategoryRepository : IRepository<Category>
    {
        Task<List<Category>> GetAllCategoryWithProducts();
    }
}
