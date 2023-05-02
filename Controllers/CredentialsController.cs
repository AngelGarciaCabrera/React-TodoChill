using Domain.Authentication.Tokenizer;
using Domain.Dtos.Dtos;
using Domain.Persistence.Services.Credentials;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace de_todo_chill.Controllers;

[ApiController]
[Route("[controller]")]
public class CredentialsController : ControllerBase
{

    private readonly ITokenizer<CredentialsDto> _tokenizer;
    
    private readonly ICredentialService _service;

    public CredentialsController(ITokenizer<CredentialsDto> appAuthSettings, ICredentialService service)
    {
        _tokenizer = appAuthSettings;
        _service = service;
    }

    [HttpPost("authorize")]
    public Task<IActionResult> Login([FromBody] CredentialsDto credential)
    {
        if (credential.Email.IsNullOrEmpty())
        {
            return Task.FromResult<IActionResult>(BadRequest());
        }

        if (!_service.Exists(credential))
        {
            return Task.FromResult<IActionResult>(BadRequest());
        }

        var token = _tokenizer.GenerateToken(credential);

        Response.Headers.Add(ITokenizer<CredentialsDto>.TOKEN_NAME, token);
        
        return Task.FromResult<IActionResult>(Ok("Logged"));
    }
    
    [HttpDelete("authorize")]
    public Task<IActionResult> SignOut()
    {
        Response.Headers.Remove(ITokenizer<CredentialsDto>.TOKEN_NAME);
        
        return Task.FromResult<IActionResult>(Ok("Removed"));
    }
}