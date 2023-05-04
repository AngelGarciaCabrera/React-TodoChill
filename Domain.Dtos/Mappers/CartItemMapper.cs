using Domain.Dtos.Dtos;
using Domain.Entities.Models;

namespace de_todo_chill.Domain.us.Mappers;

internal class CartItemMapper : IEntityDependantMapper<CartItem, CartItemDto>
{
    private static CartItemMapper? _mapper;

    private CartItemMapper()
    {
    }

    public static CartItemMapper GetInstance()
    {
        return _mapper ??= new CartItemMapper();
    }

    public CartItem MapTo(CartItemDto? c)
    {
        var cartItem = MapToWithOut(c);

        if (c != null)
        {
            cartItem.User = UserMapper.GetInstance()
                .MapToWithOut(c.User);
        }

        return cartItem;
    }

    public CartItemDto MapFrom(CartItem? c)
    {
        var cartItem = MapFromWithOut(c);

        if (c != null)
        {
            cartItem.User = UserMapper.GetInstance()
                .MapFromWithOut(c.User);
        }

        return cartItem;
    }

    public CartItem MapToWithOut(CartItemDto? c)
    {
        if (c == null)
        {
            return new CartItem();
        }
        
        return new CartItem()
        {
            Id = c.Id ?? "",
            Quantity = c.Quantity ?? -1,
        };
    }

    public CartItemDto MapFromWithOut(CartItem? c)
    {
        if (c == null)
        {
            return new CartItemDto();
        }
        
        return new CartItemDto()
        {
            Id = c.Id,
            Quantity = c.Quantity,
        };
    }
}