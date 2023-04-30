using Domain.Contexts;
using Domain.Persistence.Repositories.User;
using Microsoft.EntityFrameworkCore;

namespace Domain.Persistence.Repositories.CartItems;

public class SuggestionRepository : ISuggestionRepository
{
    private readonly MysqlDbContext _ctx;

    public SuggestionRepository(MysqlDbContext ctx)
    {
        _ctx = ctx;
    }

    public Entities.Models.Suggestion? AddEntity(Entities.Models.Suggestion suggestion)
    {
        var entityEntry = _ctx.Suggestions.Add(suggestion);

        return entityEntry.State != EntityState.Added ? null : entityEntry.Entity;
    }

    public Entities.Models.Suggestion? UpdateEntity(Entities.Models.Suggestion suggestion)
    {
        if (suggestion.Id == 0)
        {
            return null;
        }

        var entityEntry = _ctx.Suggestions.Update(suggestion);

        return entityEntry.State != EntityState.Modified ? null : entityEntry.Entity;
    }

    public ICollection<Entities.Models.Suggestion> GetEntities(int page)
    {
        return GetEntities(page, IUserRepository.DEFAULT_LIST_CONTENT);
    }

    public ICollection<Entities.Models.Suggestion> GetEntities(int page, int maxRecords)
    {
        return _ctx.Suggestions
            .OrderBy(c => c.Id)
            .Skip((page - 1) * maxRecords)
            .Take(maxRecords)
            .ToList();
    }

    public Entities.Models.Suggestion? GetEntityBy(int id)
    {
        return _ctx.Suggestions.Find(id);
    }

    public bool Exists(int id)
    {
        return _ctx.Suggestions.Any(u => u.Id == id);
    }

    public bool Exists(Entities.Models.Suggestion cart)
    {
        return Exists(cart.Id);
    }

    public Entities.Models.Suggestion? DeleteEntity(int id)
    {
        var suggestion = GetEntityBy(id);

        return suggestion == null ? null : _ctx.Suggestions.Remove(suggestion).Entity;
    }

    public Entities.Models.Suggestion? GetBy(Entities.Models.User u)
    {
        return _ctx.Suggestions
            .FirstOrDefault(c => c.UserId == u.Id);
    }

}