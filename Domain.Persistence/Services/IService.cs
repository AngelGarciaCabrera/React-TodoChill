namespace Domain.Persistence.Services;

public interface IService<ID, TD>
    where TD : class
{
    protected const int DEFAULT_MAX_RECORDS = 5;

    List<TD> Get(int page, int? maxRecord);
    TD GetBy(ID id);
    
    TD? Create(TD e);

    TD? Update(TD e);

    bool Exists(TD e);

    TD? Delete(ID e);
}