using Microsoft.EntityFrameworkCore;
using RecruitmentTask.Domain.Entities;

namespace RecruitmentTask.DataAccess
{
    public sealed class ApplicationDbContext : DbContext
    {
        public DbSet<Todo> ToDos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseInMemoryDatabase("AppDatabase");
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Todo[] seeds = new Todo[10];

            for (int i = 1; i <= 10; i++)
            {
                var randomNumber = new Random(i);

                seeds[i - 1] = new Todo
                {
                    Id = Guid.NewGuid(),
                    Title = $"TestTile_{i}",
                    Description = $"TestDescription_{i}",
                    DeadlineDate = DateTime.UtcNow.AddDays(randomNumber.Next(-5, 5)),
                    CreatedDate = DateTime.UtcNow.AddDays(-6)
                };
            }

            modelBuilder.Entity<Todo>().HasData(seeds);
        }
    }
}
