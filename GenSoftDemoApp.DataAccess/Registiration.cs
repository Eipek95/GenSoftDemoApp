using GemSoftDemoApp.DataAccess.Abstract;
using GemSoftDemoApp.DataAccess.Concrete;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GemSoftDemoApp.DataAccess
{
    public static class Registiration
    {
        public static void AddDalServiceExtensions(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IBrandRepository, BrandRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IOrderDetailRepository, OrderDetailRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();

        }
    }
}
