using GenSoftDemoApp.Business.Concrete;
using GenSoftDemoApp.Business.Abstract;
using GenSoftDemoApp.Business.Concrete;
using GenSoftDemoApp.Business.Configurations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace GenSoftDemoApp.Business
{
    public static class Registiration
    {
        public static void AddBusinessServiceExtensions(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddScoped(typeof(IGenericService<,,,>), typeof(GenericManager<,,,>));

            
            services.AddScoped<IProductService, ProductManager>();
            services.AddScoped<IOrderService, OrderManager>();
            services.AddScoped<IOrderDetailService, OrderDetailManager>();
            services.AddScoped<ICategoryService, CategoryManager>();
         
            services.AddScoped<IJwtService, JwtService>();
            services.AddScoped<IUserService, UserManager>();
            services.AddScoped<IRoleService, RoleManager>();



            services.Configure<JwtTokenOptions>(configuration.GetSection("TokenOptions"));
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
        }
    }
}
