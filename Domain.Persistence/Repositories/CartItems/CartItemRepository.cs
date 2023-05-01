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

    public Entities.Models.CartItem? AddEntity(Entities.Models.CartItem cart)
    {
        try
        {
            var entityEntry = _ctx.CartItems.Add(cart);

            return entityEntry.State != EntityState.Added ? null : entityEntry.Entity;
        }
        finally
        {
            _ctx.SaveChanges();
        }
    }

    public Entities.Models.CartItem? UpdateEntity(Entities.Models.CartItem cart)
    {
        try
        {
            if (cart.Id == string.Empty)
            {
                return null;
            }

            var entityEntry = _ctx.CartItems.Update(cart);

            return entityEntry.State != EntityState.Modified ? null : entityEntry.Entity;
        }
        finally
        {
            _ctx.SaveChanges();
        }
    }

    public ICollection<Entities.Models.CartItem> GetEntities(int page)
    {
        return GetEntities(page, IUserRepository.DEFAULT_LIST_CONTENT);
    }

    public ICollection<Entities.Models.CartItem> GetEntities(int page, int maxRecords)
    {
        return _ctx.CartItems
            .OrderBy(c => c.UserId)
            .Skip((page - 1) * maxRecords)
            .Take(maxRecords)
            .ToList();
    }

    public Entities.Models.CartItem? GetEntityBy(string id)
    {
        return _ctx.CartItems.Find(id);
    }

    public bool Exists(string id)
    {
        return _ctx.CartItems.Any(u => u.Id == id);
    }

    public bool Exists(Entities.Models.CartItem cart)
    {
        return Exists(cart.Id);
    }

    public Entities.Models.CartItem? DeleteEntity(string id)
    {
        try
        {
            var product = GetEntityBy(id);

            return product == null ? null : _ctx.CartItems.Remove(product).Entity;
        }
        finally
        {
            _ctx.SaveChanges();
        }
    }

    public ICollection<Entities.Models.CartItem>? GetBy(Entities.Models.User u)
    {
        return _ctx.CartItems
            .Where(c => c.UserId == u.Id)
            .ToList();
    }

    public ICollection<Entities.Models.CartItem>? GetBy(Entities.Models.Product p)
    {
        return _ctx.CartItems.Where(c => c.ProductId == p.Id)
            .ToList();
    }
}