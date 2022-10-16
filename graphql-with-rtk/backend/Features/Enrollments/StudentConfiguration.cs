using backend.Features.Enrollments.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace backend.Features.Enrollments;

public class StudentConfiguration : IEntityTypeConfiguration<Student>
{
    public void Configure(EntityTypeBuilder<Student> builder)
    {
        builder
            .HasMany(student => student.Courses)
            .WithMany(course => course.Students)
            .UsingEntity<Enrollment>(
                right => right.HasOne(enrollment => enrollment.Course)
                    .WithMany().HasForeignKey(enrollment => enrollment.CourseId),
                left => left.HasOne(enrollment => enrollment.Student)
                    .WithMany().HasForeignKey(enrollment => enrollment.StudentId));
    }
} 