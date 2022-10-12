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
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Class>()
                .HasOne(p => p.Teacher)
                .WithMany(x => x.Classes)
                .HasForeignKey(x => x.TeacherForeignKey);

            modelBuilder.Entity<Student>()
                .HasMany(x => x.Classes)
                .WithMany(x => x.Students)
                .UsingEntity<ClassStudent>(
                    j => j.HasOne(x => x.Class).WithMany(x => x.ClassStudents).HasForeignKey(x => x.ClassId),
                    j => j.HasOne(ct => ct.Student).WithMany(t => t.ClassStudents).HasForeignKey(ct => ct.StudentId),
                    j =>
                    {
                        j.Property(ct => ct.StartDate).HasDefaultValueSql("CURRENT_TIMESTAMP");
                        j.HasKey(t => new { t.StudentId, t.ClassId });
                    });
        }
    }
}
