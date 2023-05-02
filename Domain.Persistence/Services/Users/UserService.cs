using de_todo_chill.Domain.us.Mappers;
using Domain.Dtos.Dtos;
using Domain.Persistence.Repositories.User;
using Domain.Persistence.Services.Credentials;

namespace Domain.Persistence.Services;

public class UserService : IUserService
{
    private readonly EntityMapper _mapper;

    private readonly IUserRepository _repository;
    private readonly ICredentialService _credentialService;

    public UserService(IUserRepository repository, EntityMapper mapper, ICredentialService credentialService)
    {
        _repository = repository;
        _mapper = mapper;
        _credentialService = credentialService;
    }

    public List<UserDto> Get(int page, int? maxRecord)
    {
        return _repository.GetEntities(page, maxRecord ?? IUserService.DEFAULT_MAX_RECORDS)
            .Select(user => _mapper.MapFrom(user))
            .Where(u => u.Id != 0)
            .ToList();
    }

    public UserDto GetBy(int id)
    {
        return _mapper.MapFrom(_repository.GetEntityBy(id));
    }

    public UserDto? Create(UserDto e)
    {
        var user = _repository.AddEntity(_mapper.MapTo(e));
        
        if (!_repository.Exists(user))
        {
            return new UserDto();
        }

        e.Id = user.Id;
        e.Credentials.User = e;

        var credentialsCreated = _credentialService.Create(e.Credentials);

        return _credentialService.Exists(credentialsCreated) ? e : new UserDto();
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
        return _mapper.MapFrom(_repository.DeleteEntity(id));
    }
}