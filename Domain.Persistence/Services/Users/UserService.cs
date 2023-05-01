using de_todo_chill.Domain.us.Mappers;
using Domain.Dtos.Dtos;
using Domain.Persistence.Repositories.User;

namespace Domain.Persistence.Services;

public class UserService : IUserService
{
    private readonly EntityMapper _mapper;

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
            .Where(u => u.Id != 0)
            .ToList();
    }

    public UserDto? Create(UserDto e)
    {
        var entity = _mapper.MapTo(e);
        return _mapper.MapFrom(_repository.AddEntity(entity));
    }

    public UserDto? Update(UserDto e)
    {
        var entity = _mapper.MapTo(e);
        return _mapper.MapFrom(_repository.UpdateEntity(entity));
    }

    public bool Exists(UserDto e)
    {
        return _repository.Exists(_mapper.MapTo(e));
    }

    public UserDto? Delete(int id)
    {
        var entity = _repository.GetEntityBy(id);
        return entity != null ? _mapper.MapFrom(_repository.UpdateEntity(entity)) : new UserDto();
    }
}