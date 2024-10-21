using Internship.Products.Domain.Entities;
using Internship.Products.Domain.Interfaces;
using AutoMapper;
using Internship.Products.Application.DTOs;
using Internship.Products.Application.Interfaces;


namespace Internship.Products.Application.Services;

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;
    
    public ProductService(IProductRepository productRepository, IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<ProductDto>> GetAllProductsAsync()
    {
        var products = await _productRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<ProductDto>>(products);
      
    }
    public async Task<ProductDto> GetProductByIdAsync(int id)
    {
        var product = await _productRepository.GetByIdAsync(id);
        if (product == null)
        {
            throw new KeyNotFoundException("Product not found");
        }
        return _mapper.Map<ProductDto>(product);
        
       
    } 
    public async Task AddProductAsync(ProductDto productDto)
    {
        var product = _mapper.Map<Product>(productDto);
        await _productRepository.AddAsync(product);
    }
    public async Task UpdateProductAsync(ProductDto productDto)
    {
        var product = await _productRepository.GetByIdAsync(productDto.Id);
        if (product == null)
        {
            throw new KeyNotFoundException("Product not found");
        }

        _mapper.Map(productDto, product);
        await _productRepository.UpdateAsync(product);
    }
    public async Task DeleteProductAsync(int id)
    {
        var product = await _productRepository.GetByIdAsync(id);
        if (product == null)
        {
            throw new KeyNotFoundException("Product not found");
        }

        await _productRepository.DeleteAsync(id);
    }
}

