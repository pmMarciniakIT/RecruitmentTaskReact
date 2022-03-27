using RecruitmentTask.Domain.Dto;
using RecruitmentTask.Domain.Entities;

namespace RecruitmentTask.Domain.Services
{
    public interface ITodoService
    {
        public Task<IEnumerable<TodoDto>> GetAllTodos();
        public Task<TodoDto> GetTodoById(Guid id);
        public Task<Guid> CreateTodo(Todo todo);
        public Task<bool> DeleteTodo(Guid id);
        public Task<TodoDto> UpdateTodo(Todo todo);
        public Task<IEnumerable<TodoDto>> FindExpiredTodos();
    }
}
