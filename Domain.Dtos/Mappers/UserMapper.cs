using Domain.Dtos.Dtos;
using Domain.Entities.Models;

namespace de_todo_chill.Domain.us.Mappers;

internal class UserMapper : IEntityDependantMapper<User, UserDto>
{
    private static UserMapper? _mapper;

    private UserMapper()
    {
    }

    public static UserMapper GetInstance()
    {
        return _mapper ??= new UserMapper();
    }

    public User MapTo(UserDto? u)
    {
        var userMap = MapToWithOut(u);
        
        if (u != null)
        {
            userMap.Credentials = CredentialsMapper.GetInstance()
                .MapToWithOut(u.Credentials);
        }

        return userMap;
    }

    public UserDto MapFrom(User? u)
    {
        var userMap = MapFromWithOut(u);

        if (u != null)
        {
           userMap.Credentials = CredentialsMapper.GetInstance()
                       .MapFromWithOut(u.Credentials);
        }

        return userMap;
    }

    public User MapToWithOut(UserDto? u)
    {
        if (u == null)
        {
            return new User();
        }
        
        return new User
        {
            Id = u.Id ?? -1,
            Name = u.Name ?? "",
            Surname = u.Surname ?? "",
            Telephone = u.Telephone ?? "",
            Birthday = u.BirthDay,
        };
    }

    public UserDto MapFromWithOut(User? u)
    {
        if (u == null)
        {
            return new UserDto();
        }
        
        return new UserDto
        {
            Id = u.Id,
            Name = u.Name,
            Surname = u.Surname,
            Telephone = u.Telephone,
            BirthDay = u.Birthday,
        };
    }
}