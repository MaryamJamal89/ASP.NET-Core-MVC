using Lab1.Models;
using Microsoft.EntityFrameworkCore;

namespace Lab1.Data
{
    public class ASPCoreMVCDbContext : DbContext
    {
        public ASPCoreMVCDbContext(DbContextOptions options) : base(options) { }
        public ASPCoreMVCDbContext() { }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<StudentCourse> StudentCourse { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
        //{
        //    dbContextOptionsBuilder.UseSqlServer("Server=.; Database=ASPCoreMVCDbLabV2; Trusted_Connection=True;");
        //    base.OnConfiguring(dbContextOptionsBuilder);
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StudentCourse>().HasKey(a => new { a.StdId, a.CourseId });

            modelBuilder.Entity<Course>().HasKey(a => a.Id);
            modelBuilder.Entity<Course>().Property(a => a.Name).HasMaxLength(20).IsRequired();

            base.OnModelCreating(modelBuilder);
        }
    }
}
