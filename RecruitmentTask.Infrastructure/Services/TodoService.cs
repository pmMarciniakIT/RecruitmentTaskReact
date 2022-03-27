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

        public async Task<Guid> CreateTodo(Todo todo)
            => await _repository.CreateAsync(todo);

        public async Task<bool> DeleteTodo(Guid id)
            => await _repository.DeleteAsync(id);

        public async Task<IEnumerable<TodoDto>> FindExpiredTodos()
            => from q in (await _repository.FindExpiredTodo())
               select new TodoDto
               {
                   Id = q.Id,
                   DeadlineDate = q.DeadlineDate,
                   CreatedDate = q.CreatedDate,
                   Description = q.Description,
                   Title = q.Title
               };

        public async Task<IEnumerable<TodoDto>> GetAllTodos()
            => from q in (await _repository.GetAsync())
               select new TodoDto
               {
                   Id = q.Id,
                   DeadlineDate = q.DeadlineDate,
                   CreatedDate = q.CreatedDate,
                   Description = q.Description,
                   Title = q.Title
               };

        public async Task<TodoDto> GetTodoById(Guid id)
        {
            var result = await _repository.GetByIdAsync(id);

            return new TodoDto
            {
                Id = result.Id,
                CreatedDate = result.CreatedDate,
                Description = result.Description,
                DeadlineDate = result.DeadlineDate,
                Title = result.Title
            };
        }

        public async Task<TodoDto> UpdateTodo(Todo todo)
        {
            var result = await _repository.UpdateAsync(todo);

            return new TodoDto
            {
                Id = result.Id,
                CreatedDate = result.CreatedDate,
                Description = result.Description,
                DeadlineDate = result.DeadlineDate,
                Title = result.Title
            };
        }
    }
}