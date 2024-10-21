using AutoMapper;
using Internship.Products.Domain.Entities;
using Internship.Products.Application.DTOs;

namespace Internship.Products.Application;

public class MappingProfile: Profile
{
    public MappingProfile()
    {
        // Map between Product and ProductDto
        CreateMap<Product, ProductDto>().ReverseMap();
    } 
}