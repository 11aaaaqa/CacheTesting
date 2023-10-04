using ApplicationCore.Interfaces;
using ApplicationCore.Models;
using Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using Web.Repositories;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<ApplicationDbContext>(x => x.UseSqlServer(@"Server=(LocalDB)\MSSQLLocalDB;Database=CacheTesting;Integrated Security=true"));
builder.Services.AddTransient<ProductRepository>();
builder.Services.AddMemoryCache();
builder.Services.AddControllersWithViews();



var app = builder.Build();

app.UseDeveloperExceptionPage();

app.UseRouting();

app.MapControllerRoute("default", "{controller=Product}/{action=Products}/{id?}");

app.Run();
