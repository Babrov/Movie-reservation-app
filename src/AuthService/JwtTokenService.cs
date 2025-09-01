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
        _key = configuration["Jwt:Key"] ?? "ThisIsASecretKeyForJwtTokenGeneration";
        _issuer = configuration["Jwt:Issuer"] ?? "MovieReservationApp";
    }

    public string GenerateToken(string email)
    {
        JwtSecurityTokenHandler tokenHandler = new();

        Claim[] claims =
        {
            new(JwtRegisteredClaimNames.Email, email),
            new(ClaimTypes.Email, email),
            new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

        SecurityTokenDescriptor tokenDescriptor = new()
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.UtcNow.AddHours(1),
            Issuer = _issuer,
            Audience = _issuer,
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_key)),
                SecurityAlgorithms.HmacSha256Signature)
        };

        SecurityToken? token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
}