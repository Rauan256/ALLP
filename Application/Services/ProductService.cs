using Application.DTOs;
using Application.Interfaces;
using Domain.Entities;
using Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Application.Services;


public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;

    public ProductService(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<IEnumerable<ProductDto>> GetAllProductsAsync()
    {
        var products = await _productRepository.GetAllAsync();
        return products.Select(p => new ProductDto
        {
            Id = p.Id,
            Name = p.Name,
            Brand = p.Brand,
            Category = p.Category,
            Price = p.Price,
            Description = p.Description,
            CreatedAt = p.CreatedAt
        });
    }
    public async Task<ProductDto> GetProductByIdAsync(int id)
    {
        var product = await _productRepository.GetByIdAsync(id);
        if (product == null)
        {
            throw new KeyNotFoundException("Product not found");
        }

        return new ProductDto
        {
            Id = product.Id,
            Name = product.Name,
            Brand = product.Brand,
            Category = product.Category,
            Price = product.Price,
            Description = product.Description,
            CreatedAt = product.CreatedAt
        };
    } public async Task AddProductAsync(ProductDto productDto)
    {
        var product = new Product
        {
            Name = productDto.Name,
            Brand = productDto.Brand,
            Category = productDto.Category,
            Price = productDto.Price,
            Description = productDto.Description,
            CreatedAt = productDto.CreatedAt
        };

        await _productRepository.AddAsync(product);
    }
    public async Task UpdateProductAsync(ProductDto productDto)
    {
        var product = await _productRepository.GetByIdAsync(productDto.Id);
        if (product == null)
        {
            throw new KeyNotFoundException("Product not found");
        }

        product.Name = productDto.Name;
        product.Brand = productDto.Brand;
        product.Category = productDto.Category;
        product.Price = productDto.Price;
        product.Description = productDto.Description;
        product.CreatedAt = productDto.CreatedAt;

        await _productRepository.UpdateAsync(product);
    }
    public async Task DeleteProductAsync(int id)
    {
        await _productRepository.DeleteAsync(id);
    }
}

