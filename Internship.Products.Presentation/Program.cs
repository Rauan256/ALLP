using Internship.Products.Application;
using Internship.Products.Application.Interfaces;
using Internship.Products.Application.Services;
using Internship.Products.Domain.Interfaces;
using Internship.Products.Infrastructure.DbContext;
using Internship.Products.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using AutoMapper;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductService, ProductService>();

builder.Services.AddOcelot();
builder.Services.AddControllers();

builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(MappingProfile).Assembly);


var app = builder.Build();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
await app.UseOcelot();

app.MapControllers();

app.Run();
