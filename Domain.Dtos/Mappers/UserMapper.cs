using Domain.Dtos.Dtos;
using Domain.Entities.Models;

namespace de_todo_chill.Domain.us.Mappers;

internal class UserMapper : IEntityMapper<User, UserDto>
{
    private static UserMapper? _mapper;
        
    private UserMapper()
    {
    }

    public static UserMapper GetInstance()
    {
        return _mapper ??= new UserMapper();
    }

    public User MapTo(UserDto u)
    {
        return new User
        {
            Id = u.Id,
            Name = u.Name,
            Surname = u.Surname,
            Telephone = u.Telephone,
            Birthday = u.BirthDay,
        };
    }
        
    public UserDto MapFrom(User u)
    {
        var credentials = CredentialsMapper.GetInstance().MapFrom(u.Credentials);
        
        return new UserDto
        {
            Id = u.Id,
            Name = u.Name,
            Surname = u.Surname,
            Telephone = u.Telephone,
            BirthDay = u.Birthday,
            Credentials = credentials,
        };
    }

    public User MapToWithOut(UserDto u)
    {
        return new User
        {
            Id = u.Id,
            Name = u.Name,
            Surname = u.Surname,
            Telephone = u.Telephone,
            Birthday = u.BirthDay,
        };
    }

    public UserDto MapFromWithOut(User u)
    {
        return new UserDto
        {
            Id = u.Id,
            Name = u.Name,
            Surname = u.Surname,
            Telephone = u.Telephone,
            BirthDay = u.Birthday
        };
    }
}