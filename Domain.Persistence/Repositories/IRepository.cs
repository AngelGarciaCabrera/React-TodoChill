using System.ComponentModel.DataAnnotations;
using Domain.Entities.Interfaces;

namespace Domain.Persistence.Repositories;

public interface IRepository<ID, T> where T : IEntity<ID>
{
    protected const int DEFAULT_LIST_CONTENT = 5;

    T? AddEntity(T user);

    T? UpdateEntity(T t);

    ICollection<T> GetEntities([Range(1, int.MaxValue)] int page);
    ICollection<T> GetEntities([Range(1, int.MaxValue)] int page, int maxRecords);
    
    T? GetEntityBy(ID id);

    bool Exists(ID id);
    bool Exists(T t);

    T? DeleteEntity(ID id);
}