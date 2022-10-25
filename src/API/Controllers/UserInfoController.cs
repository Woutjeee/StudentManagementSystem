using API.Interfaces;
using API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserInfoController : GenericController<UserInfo, IUserInfo, UserInfoController>
    {
        private readonly IUserInfo _iUserInfo;

        public UserInfoController(
            IUserInfo iUserInfo,
            IStringLocalizer<UserInfoController> localizer)
            : base(iUserInfo, localizer)
        {
            _iUserInfo = iUserInfo;
        }

        [HttpPost]
        public override async Task<ActionResult<UserInfo>> Create(UserInfo userInfo)
        {
            if (userInfo is null)
                return NoContent();
            _iUserInfo.CreateUser(userInfo);
            return Ok();
        }
    }
}
