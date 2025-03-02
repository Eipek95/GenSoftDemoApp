using GenSoftDemoApp.Entity.Entities;

namespace GenSoftDemoApp.DataAccess.Abstract
{
    public interface IProductRepository:IRepository<Product>
    {

        Task<List<Product>> GetAllProductByCategoryId(int categoryId);
        Task<List<Product>> GetAllProductWithCategory();

    }
}
