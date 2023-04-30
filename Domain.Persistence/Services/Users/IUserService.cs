using Domain.Dtos.Dtos;
using Domain.Persistence.Repositories;

namespace Domain.Persistence.Services;

public interface IUserService : IService<int, UserDto>
{
    protected const int DEFAULT_MAX_RECORDS = 5;
}