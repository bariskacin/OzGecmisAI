using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OzGecmisAI.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

// Configure Entity Framework Core with SQLite
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

// Register the ApplicationDbContext in the service container
builder.Services.AddScoped<ApplicationDbContext>();

// CORS Policy
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.WithOrigins("http://localhost:5173", "https://localhost:5173")
                                .AllowAnyHeader()
                                .AllowAnyMethod()
                                .AllowCredentials();
                      });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    // Development specific middleware can be added here
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.UseCors(MyAllowSpecificOrigins); // Apply CORS policy
app.MapControllers();

app.Run();
