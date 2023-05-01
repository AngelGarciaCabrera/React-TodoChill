namespace Domain.Persistence.Repositories.Credentials;

public interface ICredentialRepository : IRepository<string, Entities.Models.Credentials>
{
    Entities.Models.Credentials? GetByEmail(string email);
    
    Entities.Models.Credentials? GetByUser(int userId);
}