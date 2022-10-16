using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Features.Enrollments.Models;

public class Enrollment
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; } = default!;
    public int StudentId { get; set; } = default!;
    public Student Student { get; set; } = default!;
    public int CourseId { get; set; } = default!;
    public Course Course { get; set; } = default!;
}