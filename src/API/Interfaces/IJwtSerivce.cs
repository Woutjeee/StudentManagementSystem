using API.Models;

namespace API.Interfaces;

public interface IJwtSerivce
{
    public string ReturnJwtKey();

    public string ReturnJwtIssuer();

    public string ReturnJwtAudience();

    public string GenerateToken(UserInfo userInfo);
}

