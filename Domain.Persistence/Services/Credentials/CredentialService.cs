using de_todo_chill.Domain.us.Mappers;
using Domain.Dtos.Dtos;
using Domain.Persistence.Repositories.Credentials;

namespace Domain.Persistence.Services.Credentials;

public class CredentialService : ICredentialService
{
    private readonly ICredentialRepository _repository;
    private readonly EntityMapper _mapper;

    public CredentialService(ICredentialRepository repository, EntityMapper mapper)
    {
        this._repository = repository;
        this._mapper = mapper;
    }

    public List<CredentialsDto> Get(int page, int? maxRecord)
    {
        return _repository.GetEntities(page, maxRecord ?? ICredentialService.DEFAULT_MAX_RECORDS)
            .Select(c => _mapper.MapFrom(c))
            .ToList();
    }

    public CredentialsDto GetBy(string id)
    {
        var credentials = _repository.GetEntityBy(id);
        return _mapper.MapFrom(credentials);
    }

    public CredentialsDto? Create(CredentialsDto e)
    {
        var credentials = _repository.AddEntity(_mapper.MapTo(e));
        return _mapper.MapFrom(credentials);
    }

    public CredentialsDto? Update(CredentialsDto e)
    {
        var credentials = _repository.UpdateEntity(_mapper.MapTo(e));
        return _mapper.MapFrom(credentials);
    }

    public bool Exists(CredentialsDto e)
    {
        return _repository.Exists(_mapper.MapTo(e));
    }

    public CredentialsDto? Delete(string e)
    {
        var credentials = _repository.DeleteEntity(e);
        return _mapper.MapFrom(credentials);
    }

    public CredentialsDto? GetByEmail(string email)
    {
        var credentials = _repository.GetByEmail(email);
        return _mapper.MapFrom(credentials);
    }

    public CredentialsDto? GetByUser(int userId)
    {
        var credentials = _repository.GetByUser(userId);
        return _mapper.MapFrom(credentials);
    }
}