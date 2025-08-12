using System.Text.Json;
using System.Text.Json.Serialization;
using CleanShop.Application.Facades;
using CleanShop.Common.Business;
using CleanShop.Common.Data;
using CleanShop.Database.Data;
using CleanShop.Database.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Win32;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// EF Core DbContext
builder.Services.AddDbContext<ShopDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Register repositories (EF-backed)
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IOrderLineRepository, OrderLineRepository>();

// Facades
builder.Services.AddScoped<IProductReadFacade, ProductReadFacade>();
builder.Services.AddScoped<IProductWriteFacade, ProductWriteFacade>();
builder.Services.AddScoped<IOrderReadFacade, OrderReadFacade>();
builder.Services.AddScoped<IOrderWriteFacade, OrderWriteFacade>();
builder.Services.AddScoped<IOrderLineReadFacade, OrderLineReadFacade>();
builder.Services.AddScoped<IOrderLineWriteFacade, OrderLineWriteFacade>();


builder.Services
    .AddControllers()
    .AddJsonOptions(options =>
    {
        JsonSerializerOptions settings = options.JsonSerializerOptions;

        settings.PropertyNamingPolicy = null;
        settings.PropertyNameCaseInsensitive = true;

        settings.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;

        // this should be a lovely trick, supporting ENUMs to be serialized
        // 1) as strings, but also
        // 2) as int as well
        settings.Converters.Add(new JsonStringEnumConverter(JsonNamingPolicy.CamelCase));
        settings.Converters.Add(new JsonStringEnumConverter());

    })
    .AddControllersAsServices();

builder.Services
    .AddControllersWithViews();

WebApplication app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();

app.UseAuthorization();

app.MapControllers();

app.UsePathBase("/");

app.UseStaticFiles();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=App}/{action=Index}/{id?}");

await app.RunAsync().ConfigureAwait(false);
