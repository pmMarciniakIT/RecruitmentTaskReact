using RecruitmentTask.Domain.Entities;

namespace RecruitmentTask.Domain.Repositories
{
    public interface ITodoRepository : IRepository<Todo>
    {
        public Task<IEnumerable<Todo>> FindExpiredTodo();
    }
}
