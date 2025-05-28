using Gadgets.Common.Contracts;
using Gadgets.Infrastructure.DataContexts;
using Gadgets.Infrastructure.Models;
using Gadgets.Infrastructure.Repositories;
using Gadgets.Infrastructure.Services;
using Gadgets.Rest;
using Microsoft.AspNetCore.Authentication.BearerToken;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddOpenApiDocument(config =>
{
    config.AddSecurity("Bearer", new NSwag.OpenApiSecurityScheme
    {
        Type = NSwag.OpenApiSecuritySchemeType.Http,
        Scheme = "bearer",
        BearerFormat = "JWT",
        In = NSwag.OpenApiSecurityApiKeyLocation.Header,
        Name = "Authorization",
        Description = "Type 'Bearer' followed by a space and your token"
    });
    
    config.OperationProcessors.Add(
        new NSwag.Generation.Processors.Security.AspNetCoreOperationSecurityScopeProcessor("Bearer"));
});

var connectionString = builder.Configuration.GetConnectionString("SqlServerConnection");

builder.Services.AddDbContext<GadgetsContext>(x => x.UseSqlServer(connectionString));

builder.Services.AddScoped<IRepository<LaptopModel>, LaptopRepository>();
builder.Services.AddScoped<IRepository<ScreenModel>, ScreenRepository>();

builder.Services.AddScoped<IAsyncCrudService<LaptopModel>, LaptopDataService>();
builder.Services.AddScoped<IAsyncCrudService<ScreenModel>, ScreenDataService>();

builder.Services.AddControllers();

builder.Services.AddAuthentication(BearerTokenDefaults.AuthenticationScheme)
    .AddBearerToken();

builder.Services.AddAuthorization();

builder.Services.AddIdentityApiEndpoints<IdentityUser>()
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<GadgetsContext>()
    //.AddUserManager<UserManager<IdentityUser>>()
    //.AddRoles<IdentityRole>()
    //.AddRoleManager<RoleManager<IdentityRole>>()
    .AddDefaultTokenProviders();

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

using (var scope = app.Services.CreateScope())
{
    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
    string[] roles = [Roles.Admin, Roles.Moderator];

    foreach (var role in roles)
    {
        if (!await roleManager.RoleExistsAsync(role))
            await roleManager.CreateAsync(new IdentityRole(role));
    }
}

app.UseAuthentication();
app.UseAuthorization();

app.UseCors("AllowAll");
app.UseHttpsRedirection();

app.UseOpenApi();
app.UseSwaggerUi();
app.UseReDoc(config =>
{
    config.Path = "/redoc";
    config.DocumentPath = "/swagger/v1/swagger.json";
});

app.MapControllers();
app.MapIdentityApi<IdentityUser>();

app.Run();