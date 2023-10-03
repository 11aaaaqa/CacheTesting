using Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<ApplicationDbContext>(x => x.UseSqlServer(@"Server=(LocalDB)\MSSQLLocalDB;Database=CacheTesting;Integrated Security=true"));
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
