using API.Dto;
using API.Interfaces;
using API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;

namespace API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthorizationController : ControllerBase
{
    private readonly IUserInfo _iUserInfo;
    private readonly IStringLocalizer<AuthorizationController> _localizer;
    private readonly IJwtSerivce _iJwtService;

    public AuthorizationController(
        IUserInfo userInfo,
        IStringLocalizer<AuthorizationController> localizer,
        IJwtSerivce jwtSerivce)
    {
        _iUserInfo = userInfo;
        _localizer = localizer;
        _iJwtService = jwtSerivce;
    }


    /// <summary>
    /// Logs the user in en returns a token for that user.
    /// </summary>
    /// <param name="loginDto"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<IActionResult> LoginUser(LoginDto loginDto)
    {
        if (loginDto is null)
        {
            return NoContent();
        }
        var user = _iUserInfo.GetUserByEmail(loginDto.Email);
        if (user is not null && _iUserInfo.Verify(user.Id, loginDto.Password))
        {
            var token = _iJwtService.GenerateToken(user);
            return Ok(token);
        }
        return BadRequest();
    }
}

