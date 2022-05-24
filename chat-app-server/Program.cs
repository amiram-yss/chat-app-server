using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using chat_app_server.Data;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<chat_app_serverContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("chat_app_serverContext") ?? throw new InvalidOperationException("Connection string 'chat_app_serverContext' not found.")));

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Ratings}/{action=Index}/{id?}");

app.Run();
