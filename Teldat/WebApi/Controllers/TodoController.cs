using Core.Interfaces;
using Infrastructure.Entities;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly ITodoService _todoService;

        public TodoController(ITodoService todoService)
        {
            _todoService = todoService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TodoItem>>> GetTodos()
        {
            var todos = await _todoService.GetAllTodosAsync();
            return Ok(todos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TodoItem>> GetTodoById(int id)
        {
            var todo = await _todoService.GetTodoByIdAsync(id);
            if (todo == null)
            {
                return NotFound();
            }
            return Ok(todo);
        }

        [HttpPost]
        public async Task<ActionResult> CreateTodo([FromBody] TodoItem todoItem)
        {
            await _todoService.AddTodoAsync(todoItem);
            return CreatedAtAction(nameof(GetTodoById), new { id = todoItem.Id }, todoItem);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateTodo(int id, [FromBody] TodoItem todoItem)
        {
            if (id != todoItem.Id)
            {
                return BadRequest();
            }

            await _todoService.UpdateTodoAsync(todoItem);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteTodo(int id)
        {
            await _todoService.DeleteTodoAsync(id);
            return NoContent();
        }

        [HttpGet("date/{date}")]
        public async Task<ActionResult<IEnumerable<TodoItem>>> GetTodosByDate(DateTime date)
        {
            var todos = await _todoService.GetTodosByDateAsync(date);
            return Ok(todos);
        }
    }
}
