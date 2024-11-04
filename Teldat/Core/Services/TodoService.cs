using Core.Interfaces;
using Infrastructure.Entities;

namespace Core.Services
{
    public class TodoService : ITodoService
    {
        private readonly ITodoRepository _todoRepository;

        public TodoService(ITodoRepository todoRepository)
        {
            _todoRepository = todoRepository;
        }

        public Task<IEnumerable<TodoItem>> GetAllTodosAsync()
        {
            return _todoRepository.GetAllAsync();
        }

        public Task<TodoItem> GetTodoByIdAsync(int id)
        {
            return _todoRepository.GetByIdAsync(id);
        }

        public Task AddTodoAsync(TodoItem item)
        {
            return _todoRepository.AddAsync(item);
        }

        public Task UpdateTodoAsync(TodoItem item)
        {
            return _todoRepository.UpdateAsync(item);
        }

        public Task DeleteTodoAsync(int id)
        {
            return _todoRepository.DeleteAsync(id);
        }
        public Task<IEnumerable<TodoItem>> GetTodosByDateAsync(DateTime date)
        {
            return _todoRepository.GetByDateAsync(date);
        }
    }
}
