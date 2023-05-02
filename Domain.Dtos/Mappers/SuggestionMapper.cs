using Domain.Dtos.Dtos;
using Domain.Entities.Models;

namespace de_todo_chill.Domain.us.Mappers;

internal class SuggestionMapper : IEntityMapper<Suggestion, SuggestionDto>
{
    private static SuggestionMapper? _mapper;

    private SuggestionMapper()
    {
    }

    public static SuggestionMapper GetInstance()
    {
        return _mapper ??= new SuggestionMapper();
    }

    public Suggestion MapTo(SuggestionDto e)
    {
        return new Suggestion()
        {
            Id = e.Id,
            Description = e.Description,
            UserId = e.User.Id,
        };
    }

    public SuggestionDto MapFrom(Suggestion e)
    {
        var user = UserMapper.GetInstance().MapFrom(e.User);
        
        return new SuggestionDto()
        {
            Id = e.Id,
            Description = e.Description,
            User = user,
        };
    }

    public Suggestion MapToWithOut(SuggestionDto e)
    {
        return new Suggestion()
        {
            Id = e.Id,
            Description = e.Description,
        };
    }

    public SuggestionDto MapFromWithOut(Suggestion e)
    {
        return new SuggestionDto()
        {
            Id = e.Id,
            Description = e.Description,
        };
    }
}