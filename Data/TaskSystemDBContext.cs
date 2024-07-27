using Microsoft.EntityFrameworkCore;
using TaskSystem.Models;

namespace TaskSystem.Data
{
    public class TaskSystemDBContext : DbContext
    {
        public TaskSystemDBContext(DbContextOptions options) : base(options)
        {

        }
        // Representations of tables
        public DbSet<UserModel> Users { get; set; }
        public DbSet<TaskModel> Tasks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.ApplyConfiguration(new TaskMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}
