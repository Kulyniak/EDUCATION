using EDUCATION.Entities;
using Microsoft.EntityFrameworkCore;

namespace EDUCATION.Models
{
    public class EFDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Question> Questions { get; set; }

        public EFDbContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=localhost\SQLEXPRESS;Database=dev;Initial Catalog=dev;Trusted_Connection=True;");
        }
    }
}
