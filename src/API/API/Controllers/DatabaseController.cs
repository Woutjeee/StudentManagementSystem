using API.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DatabaseController : ControllerBase
    {
        private readonly IDatabaseService _databaseService;

        public DatabaseController(IDatabaseService databaseService)
        {
            _databaseService = databaseService;
        }

        /// <summary>
        /// Used for testing if we can establish a connection or not
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult CreateConnection()
        {
            if (_databaseService.CreateConnection())
            {
                return Ok();
            }
            return BadRequest();
        }
    }
}
