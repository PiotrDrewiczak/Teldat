using Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
namespace Infrastructure.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<TodoItem> TodoItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.Entity<TodoItem>()
             .HasIndex(t => t.Date);
        }
    }
}
