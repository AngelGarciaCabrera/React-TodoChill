using Domain.Dtos.Dtos;
using Domain.Entities.Models;

namespace de_todo_chill.Domain.us.Mappers;

/**General class to map entities to its DTO'S.*/
// TODO add scope to application
public class EntityMapper
{
    public EntityMapper()
    {
    }

    #region Users

    public User MapTo(UserDto? u)
    {
        return u != null ? UserMapper.GetInstance().MapTo(u) : new User();
    }

    public UserDto MapFrom(User? u)
    {
        return u != null ? UserMapper.GetInstance().MapFrom(u) : new UserDto();
    }
    public User MapToWithOut(UserDto? u)
    {
        return u != null ? UserMapper.GetInstance().MapToWithOut(u) : new User();
    }

    public UserDto MapFromWithOut(User? u)
    {
        return u != null ? UserMapper.GetInstance().MapFromWithOut(u) : new UserDto();
    }
    
    

    #endregion

    #region Credentials

    public Credentials MapTo(CredentialsDto? u)
    {
        return u != null ? CredentialsMapper.GetInstance().MapTo(u) : new Credentials();
    }

    public CredentialsDto MapFrom(Credentials? u)
    {
        return u != null ? CredentialsMapper.GetInstance().MapFrom(u) : new CredentialsDto();
    }
    
    public Credentials MapToWithOut(CredentialsDto? u)
    {
        return u != null ? CredentialsMapper.GetInstance().MapToWithOut(u) : new Credentials();
    }

    public CredentialsDto MapFromWithOut(Credentials? u)
    {
        return u != null ? CredentialsMapper.GetInstance().MapFromWithOut(u) : new CredentialsDto();
    }

    #endregion

    #region Products

    public Product MapTo(ProductDto? u)
    {
        return u != null ? ProductMapper.GetInstance().MapTo(u) : new Product();
    }

    public ProductDto MapFrom(Product? u)
    {
        return u != null ? ProductMapper.GetInstance().MapFrom(u) : new ProductDto();
    }
    
    #endregion

    #region CartItem

    public CartItem MapTo(CartItemDto? u)
    {
        return u != null ? CartItemMapper.GetInstance().MapTo(u) : new CartItem();
    }

    public CartItemDto MapFrom(CartItem? u)
    {
        return u != null ? CartItemMapper.GetInstance().MapFrom(u) : new CartItemDto();
    }
    
    public CartItem MapToWithOut(CartItemDto? u)
    {
        return u != null ? CartItemMapper.GetInstance().MapToWithOut(u) : new CartItem();
    }

    public CartItemDto MapFromWithOut(CartItem? u)
    {
        return u != null ? CartItemMapper.GetInstance().MapFromWithOut(u) : new CartItemDto();
    }

    #endregion

    #region Suggestion

    public Suggestion MapTo(SuggestionDto? u)
    {
        return u != null ? SuggestionMapper.GetInstance().MapTo(u) : new Suggestion();
    }

    public SuggestionDto MapFrom(Suggestion? u)
    {
        return u != null ? SuggestionMapper.GetInstance().MapFrom(u) : new SuggestionDto();
    }
    
    public Suggestion MapToWithOut(SuggestionDto? u)
    {
        return u != null ? SuggestionMapper.GetInstance().MapToWithOut(u) : new Suggestion();
    }

    public SuggestionDto MapFromWithOut(Suggestion? u)
    {
        return u != null ? SuggestionMapper.GetInstance().MapFromWithOut(u) : new SuggestionDto();
    }

    #endregion
}