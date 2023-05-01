using Domain.Dtos.Dtos;
using Domain.Entities.Models;

namespace de_todo_chill.Domain.us.Mappers;

internal class CartItemMapper : IEntityMapper<CartItem, CartItemDto>
{
    private static CartItemMapper? _mapper;

    private CartItemMapper()
    {
    }

    public static CartItemMapper GetInstance()
    {
        return _mapper ??= new CartItemMapper();
    }

    public CartItem MapTo(CartItemDto c)
    {
        return new CartItem()
        {
            Id = c.Id,
            UserId = c.User.Id,
            ProductId = c.Product.Id,
            Quantity = c.Quantity,
        };
    }

    public CartItemDto MapFrom(CartItem c)
    {
        var user = UserMapper.GetInstance().MapFrom(c.User);

        var product = ProductMapper.GetInstance().MapFrom(c.Product);
        
        return new CartItemDto()
        {
            Id = c.Id,
            User = user,
            Product = product,
            Quantity = c.Quantity,
        };
    }
}