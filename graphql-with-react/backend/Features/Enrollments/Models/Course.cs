using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Features.Enrollments.Models;

public class Course
{

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; } = default!;
    public string Title { get; set; } = default!;
    public ICollection<Student> Students { get; set; } = default!;
}