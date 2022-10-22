using backend.Features.Enrollments.Models;


namespace backend.Features.Enrollments;

public class EnrollmentsQuery
{
    [UseProjection]
    [UseFiltering]
    public IQueryable<Student> GetStudents([Service] EnrollmentsContext enrollmentsContext) =>
        enrollmentsContext.Students;
    
    [UseSingleOrDefault]
    [UseProjection]
    public IQueryable<Student> GetStudent([Service] EnrollmentsContext enrollmentsContext, int id) =>
        enrollmentsContext.Students.Where(student => student.Id == id);
}