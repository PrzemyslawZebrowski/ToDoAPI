using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ToDoAPI.Entities;
using ToDoAPI.Models;
using ToDoAPI.Services;

namespace ToDoAPI.Controllers
{
    [ApiController]
    [Route("api/todo")]
    [Authorize]
    public class TodoController : ControllerBase
    {
        private readonly ITodoService _service;

        public TodoController(ITodoService service)
        {
            _service = service;
        }
        [HttpGet]
        public ActionResult GetAll()
        {
            var todos = _service.GetAll();
            return Ok(todos);
        }
        [HttpGet("{id}")]
        public ActionResult GetById([FromRoute] int id)
        {
            var todos = _service.GetById(id);
            return Ok(todos);
        }

        [HttpPost]
        public ActionResult CreateTodo([FromBody] CreateToDoDto dto)
        {
            var id = _service.CreateTodo(dto);
            return Created($"api/todos/{id}", null);
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteTodo([FromRoute] int id)
        {
            _service.DeleteTodo(id);
            return NoContent();
        }
        [HttpPut("{id}")]
        public ActionResult UpdateTodo([FromRoute] int id, [FromBody] UpdateToDoDto dto)
        {
            _service.UpdateTodo(id, dto);
            return NoContent();
        }
    }
}
