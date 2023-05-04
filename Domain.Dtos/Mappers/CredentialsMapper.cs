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
            credentials.UserId = credentials.User.Id;
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

        var credentials = new Credentials();
        
        if (e != null)
        {
            credentials.Id = e.Id;
            credentials.Email = e.Email ?? "";
            credentials.Password = e.Password ?? "";
        }

        return credentials;
    }

    public CredentialsDto MapFromWithOut(Credentials? e)
    {
        var credentials = new CredentialsDto();
        
        if (e != null)
        {
            credentials.Id = e.Id;
            credentials.Email = e.Email;
            credentials.Password = e.Password;
        }

        return credentials;
    }
}