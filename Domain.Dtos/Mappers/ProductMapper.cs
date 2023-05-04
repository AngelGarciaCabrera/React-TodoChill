using Domain.Dtos.Dtos;
using Domain.Entities.Models;

namespace de_todo_chill.Domain.us.Mappers;

internal class ProductMapper : IEntityMapper<Product, ProductDto>
{
    private static ProductMapper? _mapper;
        
    private ProductMapper()
    {
    }

    public static ProductMapper GetInstance()
    {
        return _mapper ??= new ProductMapper();
    }
    
    public Product MapTo(ProductDto? p)
    {
        return MapToWithOut(p);
    }
    
    public ProductDto MapFrom(Product? p)
    {
        return MapFromWithOut(p);
    }

    protected Product MapToWithOut(ProductDto? p)
    {
        if (p == null)
        {
            return new Product();
        }
        
        return new Product()
        {
            Id = p.Id ?? -1,
            Name = p.Name ?? "",
            Description = p.Description ?? "",
            Price = p.Price ?? -1D,
        };
    }

    protected ProductDto MapFromWithOut(Product? p)
    {
        if (p == null)
        {
            return new ProductDto();
        }
        
        return new ProductDto()
        {
            Id = p.Id,
            Name = p.Name,
            Description = p.Description,
            Price = p.Price,
        };
    }
}