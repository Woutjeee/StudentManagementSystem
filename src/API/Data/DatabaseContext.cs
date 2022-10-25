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
        public DbSet<UserInfo> Users { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Student> Students { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Class>()
                .HasOne(p => p.Teacher)
                .WithMany(x => x.Classes)
                .HasForeignKey(x => x.TeacherForeignKey);

            modelBuilder.Entity<Class>()
                .HasMany(x => x.Students)
                .WithMany(x => x.Classes)
                .UsingEntity<ClassStudent>(
                    x => x.HasOne(x => x.Student).WithMany(x => x.ClassStudents).HasForeignKey(x => x.StudentId).OnDelete(DeleteBehavior.NoAction),
                    x => x.HasOne(x => x.Class).WithMany(x => x.ClassStudents).HasForeignKey(x => x.ClassId).OnDelete(DeleteBehavior.NoAction),
                    x =>
                    {
                        x.Property(pt => pt.StartDate).HasDefaultValueSql("CURRENT_TIMESTAMP");
                        x.HasKey(x => new { x.ClassId, x.StudentId });
                    }
                );

            modelBuilder.Entity<Student>().Property(x => x.StudentNumber).ValueGeneratedOnAdd();
        }
    }
}
