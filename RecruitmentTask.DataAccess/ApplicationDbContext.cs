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
            Todo[] seeds = new Todo[100];

            for (int i = 1; i <= 100; i++)
            {
                var randomNumber = new Random(i);

                seeds[i - 1] = new Todo
                {
                    Id = Guid.NewGuid(),
                    Title = $"TestTile_{i}",
                    Description = $"TestDescription_{i}",
                    DeadlineDate = DateTime.Now.AddDays(randomNumber.Next(0, 5)),
                    CreatedDate = DateTime.Now.AddDays(-3)
                };
            }

            modelBuilder.Entity<Todo>().HasData(seeds);
        }
    }
}
