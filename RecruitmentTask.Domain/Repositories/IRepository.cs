namespace RecruitmentTask.Domain.Repositories
{
    public interface IRepository<T>
    {
        Task<IEnumerable<T>> GetAsync();
        Task<T> GetByIdAsync(Guid id);
        Task<T> UpdateAsync(T todo);
        Task<bool> DeleteAsync(Guid id);
        Task<Guid> CreateAsync(T todo);
    }
}
