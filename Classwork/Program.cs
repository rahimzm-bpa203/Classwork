using Classwork.DAL;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<AppDbContext>(opt=>
opt.UseSqlServer(builder.Configuration.GetConnectionString("Default")
)
);

var app = builder.Build();

app.UseStaticFiles();

app.MapControllerRoute(
    "Admin",
    "{Area:exists}/{controller=Dashboarrd}/{action=Index}/{id?}");

app.MapControllerRoute(
    "default",
    "{controller=Home}/{action=Index}/{id?}");

app.Run();
