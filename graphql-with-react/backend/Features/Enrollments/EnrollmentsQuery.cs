using backend.Features.Enrollments.Models;
using Microsoft.EntityFrameworkCore;


namespace backend.Features.Enrollments;

public class EnrollmentsQuery
{
    [UseProjection]
    [UseFiltering]
    public IQueryable<Student> GetStudents([Service] EnrollmentsContext enrollmentsContext) =>
        enrollmentsContext.Students;

    [UseProjection]
    public IQueryable<Student> GetStudent([Service] EnrollmentsContext enrollmentsContext, int id) =>
        enrollmentsContext.Students.Where(student => student.Id == id);
}