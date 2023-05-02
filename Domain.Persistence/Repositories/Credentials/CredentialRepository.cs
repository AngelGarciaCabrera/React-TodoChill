using System.ComponentModel.DataAnnotations;
using Domain.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace Domain.Persistence.Repositories.Credentials;

public class CredentialRepository : ICredentialRepository
{
    private readonly MysqlDbContext _ctx;

    public CredentialRepository(MysqlDbContext ctx)
    {
        _ctx = ctx;
    }

    public Entities.Models.Credentials? AddEntity(Entities.Models.Credentials c)
    {
        try
        {
            if (!string.IsNullOrEmpty(c.Id) && c.Id != "0")
            {
                return new Entities.Models.Credentials();
            }

            c.Id = Guid.NewGuid().ToString().Split("-")[0];

            var entityEntry = _ctx.Credentials.Add(c);

            return entityEntry.State != EntityState.Added ? new Entities.Models.Credentials() : entityEntry.Entity;
        }
        finally
        {
            _ctx.SaveChanges();
        }
    }

    public Entities.Models.Credentials? UpdateEntity(Entities.Models.Credentials c)
    {
        try
        {
            if (string.IsNullOrEmpty(c.Id))
            {
                return new Entities.Models.Credentials();
            }

            var entityEntry = _ctx.Credentials.Update(c);

            return entityEntry.State != EntityState.Modified ? new Entities.Models.Credentials() : entityEntry.Entity;
        }
        finally
        {
            _ctx.SaveChanges();
        }
    }

    public ICollection<Entities.Models.Credentials> GetEntities([Range(1, int.MaxValue)] int page)
    {
        return GetEntities(page, ICredentialRepository.DEFAULT_LIST_CONTENT);
    }

    public ICollection<Entities.Models.Credentials> GetEntities([Range(1, int.MaxValue)] int page, int maxRecords)
    {
        return _ctx.Credentials
            .OrderBy(c => c.Email)
            .Skip((page - 1) * maxRecords)
            .Take(maxRecords)
            .ToList();
    }

    public Entities.Models.Credentials? GetEntityBy(string id)
    {
        return _ctx.Credentials.FirstOrDefault(c => c.Id == id);
    }

    public bool Exists(string id)
    {
        return _ctx.Credentials.Any(c => c.Id == id);
    }

    public bool Exists(Entities.Models.Credentials t)
    {
        return t.Id.IsNullOrEmpty() ?
            _ctx.Credentials.Any(c => c.Email == t.Email) :
            Exists(t.Id);
    }

    public Entities.Models.Credentials? DeleteEntity(string id)
    {
        try
        {
            var credentials = GetEntityBy(id);

            if (credentials == null)
            {
                return new Entities.Models.Credentials();
            }

            var entityEntry = _ctx.Credentials.Remove(credentials);

            return entityEntry.State != EntityState.Modified ?
                new Entities.Models.Credentials() : entityEntry.Entity;
        }
        finally
        {
            _ctx.SaveChanges();
        }
    }

    public Entities.Models.Credentials? GetByEmail(string email)
    {
        return _ctx.Credentials.FirstOrDefault(c => c.Email == email);

    }

    public Entities.Models.Credentials? GetByUser(int userId)
    {
        return _ctx.Credentials.FirstOrDefault(c => c.UserId == userId);

    }
}