using API.Interfaces;
using API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Teacher, Administrator")]
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

        /// <summary>
        /// Create a new class, must provide a valid teacher id otherwise the new class cant be created.
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        [HttpPost]
        public override async Task<ActionResult<Class>> Create(Class c)
        {
            var teacher = _iTeacher.GetById(c.TeacherForeignKey);
            if (teacher is null)
                return NotFound(_localizer.GetString("NoValidTeacherIdProvided").Value);
            if (c is null)
                return NoContent();
            return await Task.FromResult(_iClass.Create(c));
        }
    }
}
