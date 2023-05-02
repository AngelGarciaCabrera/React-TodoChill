namespace Domain.Dtos.Dtos;

public class CredentialsDto
{

    
    public string Id { get; set; }
    public string? Email { get; set; }
    public string? Password { set; get; }
    
    public UserDto? User { set; get; }
}