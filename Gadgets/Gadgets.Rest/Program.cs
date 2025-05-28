using Gadgets.Common.Contracts;
using Gadgets.Infrastructure.DataContexts;
using Gadgets.Infrastructure.Models;
using Gadgets.Infrastructure.Repositories;
using Gadgets.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddSwaggerDocument();

var connectionString = builder.Configuration.GetConnectionString("SqlServerConnection");

builder.Services.AddDbContext<GadgetsContext>(x => x.UseSqlServer(connectionString));

builder.Services.AddScoped<IRepository<LaptopModel>, LaptopRepository>();
builder.Services.AddScoped<IRepository<ScreenModel>, ScreenRepository>();

builder.Services.AddScoped<IAsyncCrudService<LaptopModel>, LaptopDataService>();
builder.Services.AddScoped<IAsyncCrudService<ScreenModel>, ScreenDataService>();

builder.Services.AddControllers();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy
            .AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseCors("AllowAll");

app.UseHttpsRedirection();
app.MapControllers();

app.UseOpenApi();
app.UseSwaggerUi();
app.UseReDoc(config =>
{
    config.Path = "/redoc";
    config.DocumentPath = "/swagger/v1/swagger.json";
});

app.Run();