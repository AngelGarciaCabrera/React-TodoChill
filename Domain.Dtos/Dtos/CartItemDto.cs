namespace Domain.Dtos.Dtos;

public class CartItemDto
{
    public string Id { get; set; }
    public UserDto User { get; set; }
    public ICollection<ProductDto> Products { get; set; }
}