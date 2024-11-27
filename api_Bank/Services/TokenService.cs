using api_Bank.Interfaces;
using api_bank.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

public class TokenService : ITokenService
{
    private readonly IConfiguration _config;
    private readonly SymmetricSecurityKey _key;

    public TokenService(IConfiguration config)
    {
        _config = config;

        var signinKey = _config["JWT:SigninKey"];
        if (string.IsNullOrEmpty(signinKey))
        {
            throw new InvalidOperationException("JWT:SigninKey is not configured in appsettings.json");
        }

        _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(signinKey));
    }

    public string CreateToken(User user)
    {
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Email, user.Email),
            new Claim(ClaimTypes.GivenName, user.Name),
            new Claim(ClaimTypes.Role, user.Role?.RoleName ?? "User")
        };

        var creds = new SigningCredentials(_key, SecurityAlgorithms.HmacSha512);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Issuer = _config["JWT:Issuer"],
            Audience = _config["JWT:Audience"],
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.UtcNow.AddDays(5),
            SigningCredentials = creds
        };

        var tokenHandler = new JwtSecurityTokenHandler();
        var token = tokenHandler.CreateToken(tokenDescriptor);

        return tokenHandler.WriteToken(token);
    }
}
