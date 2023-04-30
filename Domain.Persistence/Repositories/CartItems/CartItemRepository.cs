using Domain.Contexts;
using Domain.Persistence.Repositories.User;
using Microsoft.EntityFrameworkCore;

namespace Domain.Persistence.Repositories.CartItems;

public class CartItemRepository : ICartItemRepository
{
    private readonly MysqlDbContext _ctx;

    public CartItemRepository(MysqlDbContext ctx)
    {
        _ctx = ctx;
    }

    public Entities.Models.CartItems? AddEntity(Entities.Models.CartItems cart)
    {
        var entityEntry = _ctx.CartItems.Add(cart);

        return entityEntry.State != EntityState.Added ? null : entityEntry.Entity;
    }

    public Entities.Models.CartItems? UpdateEntity(Entities.Models.CartItems cart)
    {
        if (cart.Id == string.Empty)
        {
            return null;
        }

        var entityEntry = _ctx.CartItems.Update(cart);

        return entityEntry.State != EntityState.Modified ? null : entityEntry.Entity;
    }

    public ICollection<Entities.Models.CartItems> GetEntities(int page)
    {
        return GetEntities(page, IUserRepository.DEFAULT_LIST_CONTENT);
    }

    public ICollection<Entities.Models.CartItems> GetEntities(int page, int maxRecords)
    {
        return _ctx.CartItems
            .OrderBy(c => c.UserId)
            .Skip((page - 1) * maxRecords)
            .Take(maxRecords)
            .ToList();
    }

    public Entities.Models.CartItems? GetEntityBy(string id)
    {
        return _ctx.CartItems.Find(id);
    }

    public bool Exists(string id)
    {
        return _ctx.CartItems.Any(u => u.Id == id);
    }

    public bool Exists(Entities.Models.CartItems cart)
    {
        return Exists(cart.Id);
    }

    public Entities.Models.CartItems? DeleteEntity(string id)
    {
        var product = GetEntityBy(id);

        return product == null ? null : _ctx.CartItems.Remove(product).Entity;
    }

    public Entities.Models.CartItems? GetBy(Entities.Models.User u)
    {
        return _ctx.CartItems
            .FirstOrDefault(c => c.UserId == u.Id);
    }

    public ICollection<Entities.Models.CartItems>? GetBy(Entities.Models.Product p)
    {
        return _ctx.CartItems.Where(c => c.Products.Contains(p))
            .ToList();
    }
}