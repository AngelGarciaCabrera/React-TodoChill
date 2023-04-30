using Domain.Contexts;
using Domain.Persistence.Repositories.Product;
using Microsoft.EntityFrameworkCore;

namespace Domain.Persistence.Repositories.User;

public class ProductRepository : IProductRepository
{
    private readonly MysqlDbContext _ctx;
    private const double DEFAULT_PRICE = 50D;

    public ProductRepository(MysqlDbContext ctx)
    {
        _ctx = ctx;
    }

    public Entities.Models.Product? AddEntity(Entities.Models.Product product)
    {
        var entityEntry = _ctx.Products.Add(product);

        return entityEntry.State != EntityState.Added ? null : entityEntry.Entity;
    }

    public Entities.Models.Product? UpdateEntity(Entities.Models.Product user)
    {
        if (user.Id == 0)
        {
            return null;
        }

        var entityEntry = _ctx.Products.Update(user);

        return entityEntry.State != EntityState.Modified ? null : entityEntry.Entity;
    }

    public ICollection<Entities.Models.Product> GetEntities(int page)
    {
        return GetEntities(page, IUserRepository.DEFAULT_LIST_CONTENT);
    }

    public ICollection<Entities.Models.Product> GetEntities(int page, int maxRecords)
    {
        return _ctx.Products
            .OrderBy(u => u.Price)
            .Skip((page - 1) * maxRecords)
            .Take(maxRecords)
            .ToList();
    }

    public Entities.Models.Product? GetEntityBy(int id)
    {
        return _ctx.Products.Find(id);
    }

    public bool Exists(int id)
    {
        return _ctx.Products.Any(u => u.Id == id);
    }

    public bool Exists(Entities.Models.Product user)
    {
        return Exists(user.Id);
    }

    public Entities.Models.Product? DeleteEntity(int id)
    {
        var product = GetEntityBy(id);

        return product == null ? null : _ctx.Products.Remove(product).Entity;
    }
}