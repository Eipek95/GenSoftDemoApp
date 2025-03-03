using GenSoftDemoApp.UI.Helpers;
using GenSoftDemoApp.UI.Services.SessionServices;
using GenSoftDemoApp.UI.Services.TokenServices;
using GenSoftDemoApp.UI.Services.UserServices;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Stripe;
using System.Net.Http.Headers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<CartService>();

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ITokenService, OETokenService>();

builder.Services.AddHttpClient("GemSoftAppClient", cfg =>
{
    var tokenService = builder.Services.BuildServiceProvider().GetRequiredService<ITokenService>();
    var token = tokenService.GetUserToken;
    cfg.BaseAddress = new Uri("https://localhost:7279/api/");
    if (token != null)
    {
        cfg.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", tokenService.GetUserToken);
    }

});
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddCookie(JwtBearerDefaults.AuthenticationScheme, opt =>
{
    opt.LoginPath = "/Auth/Login";
    opt.LogoutPath = "/Auth/Logout";
    opt.AccessDeniedPath = "/accessdenied";
    opt.Cookie.SameSite = SameSiteMode.Lax; // Stripe gibi 3. parti yönlendirmeleri için uygundur
    opt.Cookie.HttpOnly = true;
    opt.Cookie.SecurePolicy = CookieSecurePolicy.SameAsRequest;
    opt.Cookie.Name = "GemSoftAppJwt";
    opt.SlidingExpiration = true;
});

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(20);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

builder.Services.Configure<StripeSettings>(builder.Configuration.GetSection("StripeSettings"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseStatusCodePagesWithReExecute("/notfound404");

StripeConfiguration.ApiKey = builder.Configuration.GetSection("StripeSettings:SecretKey").Get<string>();



app.UseAuthentication();
app.UseAuthorization();
app.UseSession();

app.MapControllerRoute(
  name: "areas",
  pattern: "{area:exists}/{controller=Home}/{action=Dashboard}/{id?}"
);


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
