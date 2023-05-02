using Domain.Dtos.Dtos;
using Domain.Entities.Models;

namespace de_todo_chill.Domain.us.Mappers;

public class CredentialsMapper : IEntityMapper<Credentials, CredentialsDto>
{
    private static CredentialsMapper? _mapper;
    
    private CredentialsMapper()
    {
    }

    public static CredentialsMapper GetInstance()
    {
        return _mapper ??= new CredentialsMapper();
    }
    
    public Credentials MapTo(CredentialsDto e)
    {
        return new Credentials()
        {
            Id = e.Id,
            Email = e.Email,
            Password = e.Password,
            UserId = e.User.Id,
        };
    }

    public CredentialsDto MapFrom(Credentials e)
    {
        var user = UserMapper.GetInstance().MapFrom(e.User);
        
        return new CredentialsDto()
        {
            Id = e.Id,
            Email = e.Email,
            Password = e.Password,
            User = user
        };
    }

    public Credentials MapToWithOut(CredentialsDto e)
    {
        return new Credentials()
        {
            Id = e.Id,
            Email = e.Email,
            Password = e.Password,
        };
    }

    public CredentialsDto MapFromWithOut(Credentials e)
    {
        return new CredentialsDto()
        {
            Id = e.Id,
            Email = e.Email,
            Password = e.Password,
        };
    }
}