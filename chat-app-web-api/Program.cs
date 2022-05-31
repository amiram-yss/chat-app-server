using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using chat_app_web_api.Data;
const string cors_policy = "ChatAppCorsPolicy";

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<chat_app_web_apiContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("chat_app_web_apiContext") ?? throw new InvalidOperationException("Connection string 'chat_app_web_apiContext' not found.")));

builder.Services.AddCors(options =>
    options.AddPolicy(cors_policy, 
    builder => 
        builder.WithOrigins("*"))
);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(cors_policy);

app.UseAuthorization();

app.MapControllers();

app.Run();
