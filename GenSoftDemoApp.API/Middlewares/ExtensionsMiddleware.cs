using GenSoftDemoApp.Entity.Entities;
using Microsoft.AspNetCore.Identity;

namespace GenSoftDemoApp.API.Middlewares
{
    public static class ExtensionsMiddleware
    {
        public static void CreateFirstUser(WebApplication app)
        {
            using (var scoped = app.Services.CreateScope())
            {
                var userManager = scoped.ServiceProvider.GetRequiredService<UserManager<AppUser>>();

                if (!userManager.Users.Any(p => p.UserName == "admin"))
                {
                    AppUser user = new()
                    {
                        UserName = "admin",
                        Email = "admin@admin.com",
                        EmailConfirmed = true
                    };

                    userManager.CreateAsync(user, "Password123*").Wait();
                }
            }
        }
    }
}
