using Microsoft.EntityFrameworkCore;
using Repository;
using Service;
using Shope;
using NLog.Web;
var builder = WebApplication.CreateBuilder(args);
string environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

string connectionString;

if (environment == "Home")
{
    connectionString = builder.Configuration.GetConnectionString("HomeConnection");
}
else if (environment == "School")
{
    connectionString = builder.Configuration.GetConnectionString("SchoolConnection");
}
else
{
    throw new Exception("Unknown environment");
}

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
builder.Services.AddDbContext<ShopApiContext>(Options => Options.UseSqlServer(connectionString));
//builder.Services.AddDbContext< ShopApiContext>(options
//    =>options.UseSqlServer("Server=SRV2\\PUPILS;Database=Shop_Api;Trusted_Connection=True;TrustServerCertificate=True"));

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Host.UseNLog();
builder.Services.AddMemoryCache();
var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseErrorHandlingMiddleware();

app.UseRatingMiddleware();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseAuthorization();

app.MapControllers();

app.Run();
