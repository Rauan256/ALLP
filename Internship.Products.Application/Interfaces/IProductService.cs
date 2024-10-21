using Internship.Products.Application.DTOs;

namespace Internship.Products.Application.Interfaces;

public interface IProductService
{
    Task<IEnumerable<ProductDto>> GetAllProductsAsync();
    Task<ProductDto?> GetProductByIdAsync(int id);
    Task AddProductAsync(ProductDto productDto);
    Task UpdateProductAsync(ProductDto productDto);
    Task DeleteProductAsync(int id);
}