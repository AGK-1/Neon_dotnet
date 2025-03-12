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
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Postgress API", Version = "v1" });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Раскомментируйте следующую строку, если вам нужно HTTPS перенаправление
// app.UseHttpsRedirection();

app.UseAuthorization();
app.MapControllers();
app.Run();
