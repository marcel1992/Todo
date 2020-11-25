using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Todo.Core.Interfaces;
using Todo.Core.Models;

namespace Todo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TodoController : ControllerBase
    {
        private readonly ITodoRepository _repository;

        public TodoController(ITodoRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<TodoModel>>> GetTodosAsync() => Ok(await _repository.GetAllAsync());
        [HttpGet("{id}")]
        public async Task<ActionResult<TodoModel>> GetTodoAsync(int id) => Ok(await _repository.GetByIdAsync(id));
    }
}
