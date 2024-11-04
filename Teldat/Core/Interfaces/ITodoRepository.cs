using Infrastructure.Entities;

namespace Core.Interfaces
{
    public interface ITodoRepository
    {
        Task<TodoItem> GetByIdAsync(int id);
        Task<IEnumerable<TodoItem>> GetAllAsync();
        Task AddAsync(TodoItem item);
        Task UpdateAsync(TodoItem item);
        Task DeleteAsync(int id);
        Task<IEnumerable<TodoItem>> GetByDateAsync(DateTime date);
    }
}
