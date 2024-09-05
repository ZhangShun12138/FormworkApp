using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entitys;

public class Course
{
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public int ID { get; set; }
    public string Title { get; set; } = default!;
    public int Credits { get; set; }
    public ICollection<Enrollment> Enrollments { get; set; } = default!;
}
