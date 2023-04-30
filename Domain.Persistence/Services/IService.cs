namespace Domain.Persistence.Services;

public interface IService<ID, TD>
    where TD : class
{
    List<TD> Get(int page, int? maxRecord);
    
    TD? Create(TD e);

    TD? Update(TD e);

    bool Exists(TD e);

    TD? Delete(ID e);
}