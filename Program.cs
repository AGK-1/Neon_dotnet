using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using SQLE_sam;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add other necessary services
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Swagger UI and Swagger JSON configuration
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(); // Activate Swagger UI
}

app.UseHttpsRedirection(); // Corrected: No arguments here

app.UseAuthorization();
app.MapControllers();
app.Run();
