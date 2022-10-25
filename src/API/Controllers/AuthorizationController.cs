using API.Interfaces;
using API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorizationController : GenericController<UserInfo, IUserInfo, AuthorizationController>
    {
        public AuthorizationController(
            IUserInfo userInfo,
            IStringLocalizer<AuthorizationController> localizer) : base(userInfo, localizer)
        {
        }
    }
}
