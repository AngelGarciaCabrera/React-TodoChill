namespace Domain.Persistence.Repositories.CartItems;

public interface ICartItemRepository : IRepository<string, Entities.Models.CartItem>
{
    ICollection<Entities.Models.CartItem>? GetBy(Entities.Models.User u);
    
    ICollection<Entities.Models.CartItem>? GetBy(Entities.Models.Product p);
}