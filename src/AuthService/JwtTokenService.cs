using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace AuthService;

public class JwtTokenService
{
    private readonly string _issuer;
    private readonly string _key;

    public JwtTokenService(IConfiguration configuration)
    {
        _key = configuration["Jwt:Key"] ?? "super_secret_key_123!";
        _issuer = configuration["Jwt:Issuer"] ?? "MovieReservationApp";
    }

    public string GenerateToken(string email)
    {
        Claim[] claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Email, email),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

        SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_key));
        SigningCredentials creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        JwtSecurityToken token = new JwtSecurityToken(
            _issuer,
            null,
            claims,
            expires: DateTime.UtcNow.AddHours(1),
            signingCredentials: creds
        );
        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}