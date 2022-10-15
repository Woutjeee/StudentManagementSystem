using API.Interfaces;
using API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : GenericController<User, IStudent, UserController>
    {
        public UserController(
            IStudent iStudent,
            IStringLocalizer<UserController> localizer)
            : base(iStudent, localizer) 
        { 
        }
    }
}
