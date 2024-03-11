using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(option =>
    {
        option.LoginPath = "/Home/Login";
        option.ExpireTimeSpan = TimeSpan.FromMinutes(45);
    });

var app = builder.Build();

app.MapControllerRoute(name: "default", pattern: "{controller=Home}/{action=Login}/{id?}");

app.Run();
