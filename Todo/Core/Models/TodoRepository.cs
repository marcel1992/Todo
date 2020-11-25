using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using Todo.Core.Interfaces;
using Todo.Data;

namespace Todo.Core.Models
{
    public class TodoRepository : ITodoRepository
    {
        private readonly StoreContext _context;

        public TodoRepository(StoreContext context)
        {
            _context = context;
        }
        public async Task<IReadOnlyList<TodoModel>> GetAllAsync()
        {
            return await _context.Todos.ToListAsync();
        }

        public async Task<TodoModel> GetByIdAsync(int id)
        {
            return await _context.Todos.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
