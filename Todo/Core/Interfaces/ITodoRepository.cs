using System.Collections.Generic;
using System.Threading.Tasks;
using Todo.Core.Models;

namespace Todo.Core.Interfaces
{
    public interface ITodoRepository
    {
        Task<TodoModel> GetByIdAsync(int id);
        Task<IReadOnlyList<TodoModel>> GetAllAsync();
        Task AddAsync(TodoModel newTodo);
        Task UpdateAsync(TodoModel newTodo);
        Task DeleteAsync(int id);
    }
}
