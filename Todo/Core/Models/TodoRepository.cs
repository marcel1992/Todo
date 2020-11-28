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
        public async Task AddAsync(TodoModel newTodo)
        {
            _context.Todos.Add(newTodo);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(TodoModel modifiedTodo)
        {
            _context.Todos.Update(modifiedTodo);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var todo = await _context.Todos.FirstOrDefaultAsync(x => x.Id == id);
            if (todo != null)
            {
                _context.Remove(todo);
                await _context.SaveChangesAsync();
            }

        }
    }
}
