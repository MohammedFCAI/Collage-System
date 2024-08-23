using Demo.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Demo.Contexts
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext() : base()
        {

        }
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Course>()
                .HasMany(S => S.CourseResults)
                .WithOne(SC => SC.Course);

            modelBuilder.Entity<Trainee>()
                .HasMany(C => C.CourseResults)
                .WithOne(SC => SC.Trainee);

            modelBuilder.Entity<CourseResult>()
                .HasKey(SC => new { SC.TraineeId, SC.CourseId });

        }

        public DbSet<Department> Departments { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Trainee> Trainees { get; set; }
    }
}
