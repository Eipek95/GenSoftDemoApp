using GenSoftDemoApp.DataAccess.Abstract;
using GenSoftDemoApp.DataAccess.Concrete;
using GenSoftDemoApp.DataAccess.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GenSoftDemoApp.DataAccess
{
    public static class Registiration
    {
        public static void AddDalServiceExtensions(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IOrderDetailRepository, OrderDetailRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();

        }
    }
}
