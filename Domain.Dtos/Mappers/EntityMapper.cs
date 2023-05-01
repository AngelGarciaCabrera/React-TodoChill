using Domain.Dtos.Dtos;
using Domain.Entities.Models;

namespace de_todo_chill.Domain.us.Mappers;

/**General class to map entities to its DTO'S.*/
// TODO add scope to application
public class EntityMapper
{
    #region Users

    public User MapTo(UserDto u)
    {
        return UserMapper.GetInstance().MapTo(u);
    }

    public UserDto MapFrom(User u)
    {
        return UserMapper.GetInstance().MapFrom(u);
    }

    #endregion

    #region Products

    public Product MapTo(ProductDto u)
    {
        return ProductMapper.GetInstance().MapTo(u);
    }

    public ProductDto MapFrom(Product u)
    {
        return ProductMapper.GetInstance().MapFrom(u);
    }

    #endregion

    #region CartItem

    public CartItem MapTo(CartItemDto u)
    {
        return CartItemMapper.GetInstance().MapTo(u);
    }
    
    public CartItemDto MapFrom(CartItem u)
    {
        return CartItemMapper.GetInstance().MapFrom(u);
    }

    #endregion

    #region Suggestion

    public Suggestion MapTo(SuggestionDto u)
    {
        return SuggestionMapper.GetInstance().MapTo(u);
    }
    
    public SuggestionDto MapFrom(Suggestion u)
    {
        return SuggestionMapper.GetInstance().MapFrom(u);
    }


    #endregion
}