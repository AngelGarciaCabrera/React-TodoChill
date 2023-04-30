namespace Domain.Dtos.Dtos;

public class CartItemDto
{
    public string Id { get; set; }
    public UserDto User { get; set; }
    
    public ProductDto Product { get; set; }
    
    public int Quantity { get; set; }
}