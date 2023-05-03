using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Domain.Authentication.Auth;
using Domain.Dtos.Dtos;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Domain.Authentication.Tokenizer;

public class JwtTokenizer : ITokenizer<CredentialsDto>
{

    private readonly AppAuthSettings _authSettings;

    public JwtTokenizer(IOptions<AppAuthSettings> authSettings)
    {
        _authSettings = authSettings.Value;
    }

    public string GenerateToken(CredentialsDto t)
    {
        var tokenHandler = new JwtSecurityTokenHandler();

        var keyTokenSecure = Encoding.ASCII.GetBytes(_authSettings.SecretAuth);

        var claims = new Claim[]
        {
            new(JwtRegisteredClaimNames.Email, t.Email!),
            new("pwd", t.Password!),
            new(JwtRegisteredClaimNames.Jti, new Guid().ToString())
        };

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.UtcNow.AddMinutes(20),
            SigningCredentials = new SigningCredentials(
                new SymmetricSecurityKey(keyTokenSecure),
                SecurityAlgorithms.HmacSha256Signature),
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
}