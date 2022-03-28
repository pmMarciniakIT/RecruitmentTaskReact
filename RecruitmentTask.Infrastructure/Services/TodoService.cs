using RecruitmentTask.Domain.Dto;
using RecruitmentTask.Domain.Entities;
using RecruitmentTask.Domain.Repositories;
using RecruitmentTask.Domain.Services;

namespace RecruitmentTask.Infrastructure.Services
{
    public class TodoService : ITodoService
    {
        private readonly ITodoRepository _repository;

        public TodoService(ITodoRepository repository)
        {
            _repository = repository;
        }

        public async Task<Guid> CreateTodo(TodoRequestDto todo)
            => await _repository.CreateAsync(new Todo
            {
                Id = new Guid(),
                CreatedDate = DateTime.UtcNow,
                Title = todo.Title,
                Description = todo.Description,
                DeadlineDate = DateTime.Parse(todo.DeadlineDate)
            });

        public async Task<bool> DeleteTodo(Guid id)
            => await _repository.DeleteAsync(id);

        public async Task<IEnumerable<TodoDto>> FindExpiredTodos()
            => from q in (await _repository.FindExpiredTodo())
               select new TodoDto(
                    q.Id,
                    q.Title,
                    q.Description,
                    q.CreatedDate.ToString("yyyy-MM-dd"),
                    q.DeadlineDate.ToString("yyyy-MM-dd"),
                    true
                   );

        public async Task<IEnumerable<TodoDto>> GetAllTodos()
            => from q in (await _repository.GetAsync())
               select new TodoDto(
                    q.Id,
                    q.Title,
                    q.Description,
                    q.CreatedDate.ToString("yyyy-MM-dd"),
                    q.DeadlineDate.ToString("yyyy-MM-dd"),
                    DateTime.UtcNow > q.DeadlineDate
                   );

        public async Task<TodoDto> GetTodoById(Guid id)
        {
            var result = await _repository.GetByIdAsync(id);

            return new TodoDto(
                    result.Id,
                    result.Title,
                    result.Description,
                    result.CreatedDate.ToString("yyyy-MM-dd"),
                    result.DeadlineDate.ToString("yyyy-MM-dd"),
                    DateTime.UtcNow > result.DeadlineDate
                   );
        }

        public async Task<TodoDto> UpdateTodo(TodoRequestDto todo)
        {
            var entity = await _repository.GetByIdAsync(Guid.Parse(todo.Id));

            entity.Description = todo.Description;
            entity.DeadlineDate = DateTime.Parse(todo.DeadlineDate);
            entity.Title = todo.Title;

            var result = await _repository.UpdateAsync(entity);

            return new TodoDto(
                    result.Id,
                    result.Title,
                    result.Description,
                    result.CreatedDate.ToString("yyyy-MM-dd"),
                    result.DeadlineDate.ToString("yyyy-MM-dd"),
                    DateTime.UtcNow > result.DeadlineDate
                   );
        }
    }
}