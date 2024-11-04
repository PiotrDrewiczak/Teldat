using Infrastructure.Entities;

namespace Core.Interfaces
{
    public interface ITodoService
    {
        Task<IEnumerable<TodoItem>> GetAllTodosAsync();
        Task<TodoItem> GetTodoByIdAsync(int id);
        Task AddTodoAsync(TodoItem item);
        Task UpdateTodoAsync(TodoItem item);
        Task DeleteTodoAsync(int id);
        Task<IEnumerable<TodoItem>> GetTodosByDateAsync(DateTime date);
    }
}
