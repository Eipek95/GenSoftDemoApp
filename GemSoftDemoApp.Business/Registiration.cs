using GemSoftDemoApp.Business.Abstract;
using GemSoftDemoApp.Business.Concrete;
using GemSoftDemoApp.Business.Configurations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace GemSoftDemoApp.Business
{
    public static class Registiration
    {
        public static void AddBusinessServiceExtensions(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddScoped(typeof(IGenericService<,,,>), typeof(GenericManager<,,,>));

            services.AddScoped<IBrandService, BrandManager>();
            services.AddScoped<IProductService, ProductManager>();
            services.AddScoped<IOrderService, OrderManager>();
            services.AddScoped<IOrderDetailService, OrderDetailManager>();
            services.AddScoped<ICategoryService, CategoryManager>();
            services.Configure<JwtTokenOptions>(configuration.GetSection("TokenOptions"));
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddScoped<IJwtService, JwtService>();
        }
    }
}
