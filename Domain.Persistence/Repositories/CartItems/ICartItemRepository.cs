namespace Domain.Persistence.Repositories.CartItems;

public interface ICartItemRepository : IRepository<string, Entities.Models.CartItems>
{
    Entities.Models.CartItems? GetBy(Entities.Models.User u);
    
    ICollection<Entities.Models.CartItems>? GetBy(Entities.Models.Product p);
}