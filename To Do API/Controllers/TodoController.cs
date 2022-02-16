using Microsoft.AspNetCore.Mvc;
using ToDoAPI.Entities;
using ToDoAPI.Services;

namespace ToDoAPI.Controllers
{
    [ApiController]
    [Route("api/todos")]
    public class TodoController : ControllerBase
    {
        private readonly ITodoService _service;

        public TodoController(ITodoService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var todos = _service.GetAll();
            return Ok(todos);
        }
        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            var todos = _service.GetById(id);
            return Ok(todos);
        }
    }
}
