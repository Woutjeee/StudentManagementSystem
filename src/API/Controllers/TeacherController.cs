using API.Interfaces;
using API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController : GenericController<Teacher, ITeacher, TeacherController>
    {
        public TeacherController(
            ITeacher iTeahcer,
            IStringLocalizer<TeacherController> localizer)
            : base(iTeahcer, localizer)
        {
        }
    }
}
