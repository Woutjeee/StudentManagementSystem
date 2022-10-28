using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using API.Interfaces;
using API.Models;
using API.Options;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace API.Services;

public class JwtService : IJwtSerivce
{
    private readonly string _audiance;
    private readonly string _issuer;
    private readonly string _key;

    public JwtService(IOptions<ApplicationOptions> options)
    {
        _audiance = options.Value.Jwt.Audience;
        _issuer = options.Value.Jwt.Issuer;
        _key = options.Value.Jwt.Key;
    }

    public string ReturnJwtAudience()
    {
        return _audiance;
    }

    public string ReturnJwtIssuer()
    {
        return _issuer;
    }

    public string ReturnJwtKey()
    {
        return _key;
    }


    public string GenerateToken(UserInfo userInfo)
    {
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(ReturnJwtKey()));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        var claims = new[]
        {
            new Claim("Firstname", userInfo.Firstname),
            new Claim("Lastname", userInfo.Lastname),
            new Claim(ClaimTypes.Email, userInfo.Email),
            new Claim(ClaimTypes.Role, userInfo.Role)
        };

        var token = new JwtSecurityToken(
            ReturnJwtIssuer(),
            ReturnJwtAudience(),
            claims,
            expires: DateTime.Now.AddMinutes(60),
            signingCredentials: credentials);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    private TokenValidationParameters GetParameters()
    {
        return new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = ReturnJwtIssuer(),
            ValidAudience = ReturnJwtAudience(),
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(ReturnJwtKey()))
        };
    }

    public UserInfo GetUserInfo(string token)
    {
        ClaimsPrincipal principal = new JwtSecurityTokenHandler().ValidateToken(token, GetParameters(), out SecurityToken securityToken);
        return new UserInfo
        {
            Firstname = principal.Claims.FirstOrDefault(x => x.Type == "Firstname")?.Value,
            Lastname = principal.Claims.FirstOrDefault(x => x.Type == "Lastname")?.Value,
            Email = principal.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Email)?.Value,
            Role = principal.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Role)?.Value,
        };
    }
}

