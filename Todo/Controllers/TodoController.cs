using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Todo.Core.Interfaces;
using Todo.Core.Models;

namespace Todo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TodoController : ControllerBase
    {
        private readonly ITodoRepository _repository;

        public TodoController(ITodoRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("~/api/GetTodos")]
        public async Task<ActionResult<IReadOnlyList<TodoModel>>> GetTodosAsync() => Ok(await _repository.GetAllAsync());

        [HttpGet("~/api/GetTodo/{id}")]
        public async Task<ActionResult<TodoModel>> GetTodoAsync(int id) => Ok(await _repository.GetByIdAsync(id));

        [HttpPost("~/api/AddTodo")]
        public async Task<ActionResult> AddTodoAsync([FromBody] TodoModel newTodo)
        {
            await _repository.AddAsync(newTodo);
            return Ok();
        }

        [HttpPut("~/api/UpdateTodo")]
        public async Task<ActionResult> UpdateTodoAsync([FromBody] TodoModel modifiedTodo)
        {
            await _repository.UpdateAsync(modifiedTodo);
            return Ok();
        }

        [HttpDelete("~/api/DeleteTodo/{id}")]
        public async Task<ActionResult> DeleteTodoAsync(int id)
        {
            await _repository.DeleteAsync(id);
            return Ok();
        }
    }
}
