using Microsoft.EntityFrameworkCore;
using Repository;
using Service;
using Shope;
using NLog.Web;
var builder = WebApplication.CreateBuilder(args);
// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddScoped<IServiceUser, ServiceUser>();
builder.Services.AddScoped< IRepositoryUser, RepositoryUser>();

builder.Services.AddScoped<IRepositoryProduct, RepositoryProduct>();
builder.Services.AddScoped<IServiceProduct, ServiceProduct>();

builder.Services.AddScoped<IRepositoryCategory, RepositoryCategory>();
builder.Services.AddScoped<IserviceCategory, serviceCategory>();

builder.Services.AddScoped<IRepositoryOrder, RepositoryOrder>();
builder.Services.AddScoped<IServiceOrder, ServiceOrder>();

builder.Services.AddScoped<IRepositoryRating, RepositoryRating>();
builder.Services.AddScoped<IServiceRating, ServiceRating>();

builder.Services.AddDbContext< ShopApiContext>(options
    =>options.UseSqlServer("Server=SRV2\\PUPILS;Database=Shop_Api;Trusted_Connection=True;TrustServerCertificate=True"));

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Host.UseNLog();
var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRatingMiddleware();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseAuthorization();

app.MapControllers();

app.Run();
