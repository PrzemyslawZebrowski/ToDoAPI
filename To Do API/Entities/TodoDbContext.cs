using Microsoft.EntityFrameworkCore;

namespace ToDoAPI.Entities
{
    public class TodoDbContext : DbContext
    {
        private string _connectionString = @"Server=(localdb)\mssqllocaldb;Database=ToDoDatabase;Trusted_Connection=True";
        public DbSet<User> Users { get; set; }
        public DbSet<Todo> Todos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Todo>()
                .Property(t => t.Title)
                .IsRequired();

            modelBuilder.Entity<User>()
                .Property(u => u.Email)
                .IsRequired();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }
    }
}
