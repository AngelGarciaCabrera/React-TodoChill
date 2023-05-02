using Domain.Dtos.Dtos;
using Domain.Persistence.Repositories;

namespace Domain.Persistence.Services;

public interface IUserService : IService<int, UserDto>
{
}