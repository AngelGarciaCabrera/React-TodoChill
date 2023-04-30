using de_todo_chill.Domain.us.Mappers;
using Domain.Dtos.Dtos;
using Domain.Persistence.Repositories.User;

namespace Domain.Persistence.Services;

public class UserService : IUserService
{
    
    //TODO : Add scope
    private readonly EntityMapper _mapper;
    //TODO : Add scope
    private readonly IUserRepository _repository;

    public UserService(IUserRepository repository, EntityMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public List<UserDto> Get(int page, int? maxRecord)
    {
        return _repository.GetEntities(page, maxRecord ?? IUserService.DEFAULT_MAX_RECORDS)
            .Select(user => _mapper.MapFrom(user))
            .ToList();
    }

    public UserDto? Create(UserDto e)
    {
        throw new NotImplementedException();
    }

    public UserDto? Update(UserDto e)
    {
        throw new NotImplementedException();
    }

    public bool Exists(UserDto e)
    {
        throw new NotImplementedException();
    }

    public UserDto? Delete(int e)
    {
        throw new NotImplementedException();
    }
}