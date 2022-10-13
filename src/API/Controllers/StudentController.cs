using API.Interfaces;
using API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : GenericController<Student, IStudent, StudentController>
    {
        public StudentController(
            IStudent iStudent,
            IStringLocalizer<StudentController> localizer)
            : base(iStudent, localizer) 
        { 
        }
    }
}
