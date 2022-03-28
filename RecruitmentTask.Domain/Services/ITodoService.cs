using RecruitmentTask.Domain.Dto;

namespace RecruitmentTask.Domain.Services
{
    public interface ITodoService
    {
        public Task<IEnumerable<TodoDto>> GetAllTodos();
        public Task<TodoDto> GetTodoById(Guid id);
        public Task<Guid> CreateTodo(TodoRequestDto todo);
        public Task<bool> DeleteTodo(Guid id);
        public Task<TodoDto> UpdateTodo(TodoRequestDto todo);
        public Task<IEnumerable<TodoDto>> FindExpiredTodos();
    }
}
