using Domain.Dtos.Dtos;

namespace Domain.Persistence.Services.Credentials;

public interface ICredentialService : IService<string, CredentialsDto>
{
    CredentialsDto? GetByEmail(string email);

    CredentialsDto? GetByUser(int userId);
}