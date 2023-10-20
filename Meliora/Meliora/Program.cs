using Meliora.DataLayer.Model;
using Meliora.BusinessLayer.Services;
using Meliora.DataLayer.Interfaces;
using Meliora.DataLayer.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// add appconnections.json.  appconnections.json stores values that will not be copied into the build
builder.Configuration.AddConfiguration(
    new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appconnections.json")
        .Build()
);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<SONQuizContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("Default")));

// MixIns
builder.Services.AddScoped<MixInService, MixInService>();
builder.Services.AddScoped<IMixInDataService, MixInDataService>();

// Cookies
builder.Services.AddScoped<ProductService, ProductService>();
builder.Services.AddScoped<IProductDataService, ProductDataService>();

// Orders
builder.Services.AddScoped<OrderService, OrderService>();
builder.Services.AddScoped<IOrderDataService, OrderDataService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
