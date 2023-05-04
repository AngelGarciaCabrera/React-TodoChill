using Domain.Dtos.Dtos;
using Domain.Entities.Models;

namespace de_todo_chill.Domain.us.Mappers;

public class CredentialsMapper : IEntityDependantMapper<Credentials, CredentialsDto>
{
    private static CredentialsMapper? _mapper;

    private CredentialsMapper()
    {
    }

    public static CredentialsMapper GetInstance()
    {
        return _mapper ??= new CredentialsMapper();
    }

    public Credentials MapTo(CredentialsDto? e)
    {
        var credentials = MapToWithOut(e);

        if (e != null)
        {
            credentials.User = UserMapper.GetInstance()
                .MapToWithOut(e.User);
        }

        return credentials;
    }

    public CredentialsDto MapFrom(Credentials? e)
    {
        var credentials = MapFromWithOut(e);

        if (e != null)
        {
            credentials.User = UserMapper.GetInstance()
                .MapFromWithOut(e.User);
        }

        return credentials;
    }

    public Credentials MapToWithOut(CredentialsDto? e)
    {
        if (e == null)
        {
            return new Credentials();
        }
        
        return new Credentials()
        {
            Id = e.Id,
            Email = e.Email ?? "",
            Password = e.Password ?? "",
        };
    }

    public CredentialsDto MapFromWithOut(Credentials? e)
    {
        if (e == null)
        {
            return new CredentialsDto();
        }

        return new CredentialsDto()
        {
            Id = e.Id,
            Email = e.Email,
            Password = e.Password,
        };
    }
}