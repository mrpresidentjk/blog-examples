using backend.Features.Enrollments.Models;
using Microsoft.EntityFrameworkCore;

namespace backend.Features.Enrollments;

public class EnrollmentsContext : DbContext
{
    public DbSet<Course> Courses { get; set; } = default!;
    public DbSet<Student> Students { get; set; } = default!;
    public DbSet<Enrollment> Enrollments { get; set; } = default!;

    public EnrollmentsContext(DbContextOptions options) : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);

        modelBuilder.Entity<Student>().HasData(new Student
            {
                Id = 1,
                FirstName = "Fred",
                LastName = "Diaz",
                Birthday = DateTime.UtcNow.AddYears(-28).AddMonths(-3).AddDays(-10)
            }, new Student
            {
                Id = 2,
                FirstName = "Sarah",
                LastName = "Connor",
                Birthday = DateTime.UtcNow.AddYears(-19).AddMonths(-10).AddDays(-2)
            },
            new Student
            {
                Id = 3,
                FirstName = "George",
                LastName = "Roberts",
                Birthday = DateTime.UtcNow.AddYears(-25).AddMonths(-8).AddDays(-20)
            });

        modelBuilder.Entity<Course>().HasData(new Course
            {
                Id = 1,
                Title = "Artificial Intelligence"
            }, new Course
            {
                Id = 2,
                Title = "Introduction to Programming"
            }
        );

        modelBuilder.Entity<Enrollment>().HasData(new Enrollment
            {
                Id = 1,
                StudentId = 1,
                CourseId = 1
            },
            new Enrollment
            {
                Id = 2,
                StudentId = 2,
                CourseId = 1
            },
            new Enrollment
            {
                Id = 3,
                StudentId = 2,
                CourseId = 2
            },
            new Enrollment
            {
                Id = 4,
                StudentId = 3,
                CourseId = 2
            });
    }
}