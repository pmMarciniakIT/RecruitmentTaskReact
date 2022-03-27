using Microsoft.EntityFrameworkCore;
using RecruitmentTask.Domain.Entities;
using RecruitmentTask.Domain.Repositories;

namespace RecruitmentTask.DataAccess.Repositories
{
    public class TodoRepository : TRepository<Todo>, ITodoRepository
    {
        public TodoRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<Todo>> FindExpiredTodo()
            => await DbSet
                .Where(todo => todo.DeadlineDate < DateTime.UtcNow)
                .ToListAsync();
    }
}
