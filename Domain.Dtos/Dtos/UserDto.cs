using Domain.Entities.Models;

namespace Domain.Dtos.Dtos;

public class UserDto
{
    public int? Id { get; set; }
    public string? Name { get; set; }
    public string? Surname { get; set; }
    public DateTime? BirthDay { get; set; }
    public string? Telephone { get; set; }
    
    public CredentialsDto? Credentials { set; get; }
    
}