using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using SQLE_sam;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<AppDbContext>(options => 
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// Добавляем настройку HTTPS здесь, до создания объекта app
builder.Services.AddHttpsRedirection(options => { options.HttpsPort = 443; });

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Swagger UI və Swagger JSON aktivləşdirilməsi
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(); // Swagger UI aktivləşdirilir
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
