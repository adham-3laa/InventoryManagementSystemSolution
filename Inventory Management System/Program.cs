using Inventory_Management_System.CustomMiddlewares;
using InventoryManagementSystem.Abstruction.IServices;
using InventoryManagementSystem.Domain.Contracts.UOW;
using InventoryManagementSystem.Persistence.Context;
using InventoryManagementSystem.Persistence.UOW;
using InventoryManagementSystem.Service.Services;
using InventoryManagementSystem.Shared.ErrorModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddDbContext<InventoryDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IServicesManager, ServicesManager>();
builder.Services.AddAutoMapper(m => m.AddMaps(typeof(Program).Assembly));

builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.InvalidModelStateResponseFactory = context =>
    {
        var errors = context.ModelState.Where(m => m.Value.Errors.Any())
            .Select(M=>new ValidationError()
            {
                Field = M.Key,
                Errors = M.Value.Errors.Select(e => e.ErrorMessage)
            });
        var response = new ValidationErrorToReturn()
        {
            StatusCode = (int)System.Net.HttpStatusCode.BadRequest,
            Errors = errors
        };
        return new BadRequestObjectResult(response);
    };
});

var app = builder.Build();

app.UseMiddleware<CustomExceptionMiddleware>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
