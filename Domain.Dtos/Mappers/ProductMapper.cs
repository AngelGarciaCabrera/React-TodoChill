using Domain.Dtos.Dtos;
using Domain.Entities.Models;

namespace de_todo_chill.Domain.us.Mappers;

public class ProductMapper
{
    private static ProductMapper? _mapper;
        
    private ProductMapper()
    {
    }

    public static ProductMapper GetInstance()
    {
        return _mapper ??= new ProductMapper();
    }
    
    public Product MapTo(ProductDto p)
    {
        return new Product()
        {
            Id = p.Id,
            Name = p.Name,
            Description = p.Description,
            Price = p.Price,
        };
    }
    
    public ProductDto MapFrom(Product p)
    {
        return new ProductDto()
        {
            Id = p.Id,
            Name = p.Name,
            Description = p.Description,
            Price = p.Price,
        };
    }
}