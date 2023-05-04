using Domain.Dtos.Dtos;
using Domain.Entities.Models;

namespace de_todo_chill.Domain.us.Mappers;

internal class SuggestionMapper : IEntityDependantMapper<Suggestion, SuggestionDto>
{
    private static SuggestionMapper? _mapper;

    private SuggestionMapper()
    {
    }

    public static SuggestionMapper GetInstance()
    {
        return _mapper ??= new SuggestionMapper();
    }

    public Suggestion MapTo(SuggestionDto? e)
    {
        var suggestion = MapToWithOut(e);

        if (e != null)
        {
            suggestion.User = UserMapper.GetInstance()
                .MapToWithOut(e.User);
            suggestion.UserId = suggestion.User.Id;
        }

        return suggestion;
    }

    public SuggestionDto MapFrom(Suggestion? e)
    {
        var suggestion = MapFromWithOut(e);

        if (e != null)
        {
            suggestion.User = UserMapper.GetInstance()
                .MapFromWithOut(e.User);
        }

        return suggestion;
    }

    public Suggestion MapToWithOut(SuggestionDto? e)
    {
        var suggestion = new Suggestion();

        if (e != null)
        {
            suggestion.Id = e.Id ?? -1;
            suggestion.Description = e.Description ?? "";
        }

        return suggestion;
    }

    public SuggestionDto MapFromWithOut(Suggestion? e)
    {
        var suggestion = new SuggestionDto();

        if (e != null)
        {
            suggestion.Id = e.Id;
            suggestion.Description = e.Description;
        }

        return suggestion;
    }
}