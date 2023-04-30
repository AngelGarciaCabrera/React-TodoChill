namespace Domain.Dtos.Dtos;

public class SuggestionDto
{
    public int Id { set; get; }
    public string Description { get; set; }
    public UserDto User { get; set; }
}