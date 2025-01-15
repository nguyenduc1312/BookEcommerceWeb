using BookEcommerceWeb.DataAccess.Data;
using BookEcommerceWeb.DataAccess.Repositories.Interfaces;
using BookEcommerceWeb.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;
using BookEcommerceWeb.Services.Interfaces;
using BookEcommerceWeb.Services.Services;
using AutoMapper;
using BookEcommerceWeb.Services.MappingProfiles;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Identity;
using BookEcommerceWeb.Models.DTOs;
using BookEcommerceWeb.Models.Validation;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Development")));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Add AutoMapper
builder.Services.AddAutoMapper(typeof(MappingProfile));

//Dependency Injection
builder.Services.AddScoped<IUnitofWork, UnitOfWork>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<ICompanyService, CompanyService>();

//DI for validators
builder.Services.AddScoped<IValidator<CategoryDto>, CategoryValidator>();
builder.Services.AddScoped<IValidator<ProductDto>, ProductValidator>();
builder.Services.AddScoped<IValidator<CompanyDto>, CompanyValidator>();

// Register FluentValidation
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddValidatorsFromAssemblyContaining<Program>();

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
