using Domain.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Domain.Persistence.Repositories.User;

public class UserRepository : IUserRepository
{
    private readonly MysqlDbContext _ctx;

    public UserRepository(MysqlDbContext ctx)
    {
        _ctx = ctx;
    }

    public Entities.Models.User? AddEntity(Entities.Models.User user)
    {
        user.Birthday ??= DateTime.Today;

        var entityEntry = _ctx.Users.Add(user);

        return entityEntry.State != EntityState.Added ? null : entityEntry.Entity;
    }

    public Entities.Models.User? UpdateEntity(Entities.Models.User user)
    {
        if (user.Id == 0)
        {
            return null;
        }

        var entityEntry = _ctx.Users.Update(user);

        return entityEntry.State != EntityState.Modified ? null : entityEntry.Entity;
    }

    public ICollection<Entities.Models.User> GetEntities(int page)
    {
        return GetEntities(page, IUserRepository.DEFAULT_LIST_CONTENT);
    }

    public ICollection<Entities.Models.User> GetEntities(int page, int maxRecords)
    {
        return _ctx.Users
            .OrderBy(u => u.Surname)
            .Skip((page - 1) * maxRecords)
            .Take(maxRecords)
            .ToList();
    }

    public Entities.Models.User? GetEntityBy(int id)
    {
        return _ctx.Users.Find(id);
    }

    public bool Exists(int id)
    {
        return _ctx.Users.Any(u => u.Id == id);
    }

    public bool Exists(Entities.Models.User user)
    {
        return Exists(user.Id);
    }

    public Entities.Models.User? DeleteEntity(int id)
    {
        var user = GetEntityBy(id);

        return user == null ? null : _ctx.Users.Remove(user).Entity;
    }
}