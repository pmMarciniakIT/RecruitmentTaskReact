using Microsoft.EntityFrameworkCore;
using RecruitmentTask.DataAccess.Exceptions;
using RecruitmentTask.Domain.Entities;
using RecruitmentTask.Domain.Repositories;

namespace RecruitmentTask.DataAccess.Repositories
{
    public class TRepository<T> : IRepository<T> where T : EntityId
    {
        private readonly ApplicationDbContext _dbContext;
        internal readonly DbSet<T> DbSet;

        public TRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbContext.Database.EnsureCreated();

            DbSet = _dbContext.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAsync()
            => await DbSet.ToListAsync();

        public async Task<T> GetByIdAsync(Guid id)
        {
            var entity = await DbSet.FirstOrDefaultAsync(entity => entity.Id.Equals(id));

            if (entity == null)
            {
                throw new EntityNotFoundException(typeof(T));
            }

            return entity;
        }

        public async Task<Guid> CreateAsync(T entry)
        {
            await DbSet.AddAsync(entry);
            await _dbContext.SaveChangesAsync();

            return entry.Id;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var entity = await DbSet.FirstOrDefaultAsync(entity => entity.Id.Equals(id));

            if (entity == null)
            {
                throw new EntityNotFoundException(typeof(T));
            }

            DbSet.Remove(entity);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<T> UpdateAsync(T entry)
        {
            DbSet.Attach(entry).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();

            return entry;
        }
    }
}