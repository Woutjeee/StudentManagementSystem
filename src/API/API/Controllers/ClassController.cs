using System.Security.Cryptography.X509Certificates;
using API.Interfaces;
using API.Models;
using API.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassController : GenericController<Class, IClass, ClassController>
    {
        private readonly IClass _iClass;
        private readonly IStringLocalizer<ClassController> _localizer;
        private readonly ITeacher _iTeacher;

        public ClassController(
            IClass iClass,
            IStringLocalizer<ClassController> localizer,
            ITeacher teacher)
            : base(iClass, localizer)
        {
            _iClass = iClass;
            _localizer = localizer;
            _iTeacher = teacher;
        }

        [HttpPost]
        public override async Task<ActionResult<Class>> Create(Class c)
        {
            var teacher = _iTeacher.GetById(c.TeacherForeignKey);
            if (teacher is null)
                return NotFound(_localizer.GetString("").Value);
            if (c is null)
                return NoContent();
            return await Task.FromResult(_iClass.Create(c));
        }
    }
}
