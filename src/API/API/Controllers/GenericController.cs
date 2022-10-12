using API.Extensions;
using API.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenericController<T, TInterface, TController>
        : ControllerBase
        where T : class
        where TInterface : IGeneric<T>
        where TController : class
    {
        private readonly IGeneric<T> _repo;
        private readonly IStringLocalizer<TController> _localizer;

        public GenericController(
            IGeneric<T> repository,
            IStringLocalizer<TController> localizer)
        {
            _repo = repository;
            _localizer = localizer;
        }

        /// <summary>
        /// Get all the items as a list.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public virtual async Task<ActionResult<IEnumerable<T>>> GetAll()
        {
            return await Task.FromResult(_repo.GetAll());
        }

        /// <summary>
        /// Get a specific item by providing a id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public virtual async Task<ActionResult<T>> GetById(Guid id)
        {
            if (id == Guid.Empty)
                return BadRequest(_localizer.GetString("NoIdProvidedOnGet").Value);
            return await Task.FromResult(_repo.GetById(id));
        }

        /// <summary>
        /// Create a new object.
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        [HttpPost]
        public virtual async Task<ActionResult<T>> Create(T type)
        {
            if (type is null)
                return BadRequest(_localizer.GetString("NoContentPostMessage").Value);
            return await Task.FromResult(_repo.Create(type));
        }
        
        /// <summary>
        /// Update a object.
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        [HttpPut]
        public virtual async Task<ActionResult<T>> Update(T type)
        {
            if (type is null)
                return BadRequest(_localizer.GetString("NoContentPostMessage").Value);
            return await Task.FromResult(_repo.Update(type));
        }

        /// <summary>
        /// Delete a object.
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        [HttpDelete]
        public virtual async Task<ActionResult<T>> Delete(T type)
        {
            if (type is null)
                return BadRequest(_localizer.GetString("NoContentPostMessage").Value);
            return await Task.FromResult(_repo.Delete(type));
        }
    }
}
