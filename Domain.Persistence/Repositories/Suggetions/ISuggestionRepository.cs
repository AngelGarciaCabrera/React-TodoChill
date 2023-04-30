namespace Domain.Persistence.Repositories.CartItems;

public interface ISuggestionRepository : IRepository<int, Entities.Models.Suggestion>
{
    Entities.Models.Suggestion? GetBy(Entities.Models.User u);
}