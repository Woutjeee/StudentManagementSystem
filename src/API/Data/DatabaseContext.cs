using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }

        public DbSet<Class> Classes { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Student> Students { get; set; }
        


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Class>()
                .HasOne(p => p.Teacher)
                .WithMany(x => x.Classes)
                .HasForeignKey(x => x.TeacherForeignKey);

            modelBuilder.Entity<Student>().Property(x => x.StudentNumber).ValueGeneratedOnAdd();
        }
    }
}
