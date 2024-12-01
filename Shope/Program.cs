using Microsoft.EntityFrameworkCore;
using Repository;
using Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddScoped<IServiceUser, ServiceUser>();
builder.Services.AddScoped< IRepositoryUser, RepositoryUser>();
builder.Services.AddDbContext< ShopApiContext>(options
    =>options.UseSqlServer("Server=SRV2\\PUPILS;Database=Shop_Api;Trusted_Connection=True;TrustServerCertificate=True"));

var app = builder.Build();


// Configure the HTTP request pipeline.

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseAuthorization();

app.MapControllers();

app.Run();
