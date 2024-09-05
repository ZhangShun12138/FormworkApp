using System.ComponentModel.DataAnnotations;

namespace Domain.Entitys;

public enum Grade
{
    A, B, C, D, F
}
public class Enrollment
{
    public int ID { get; set; }
    public int CourseID { get; set; }
    public int StudentID { get; set; }
    [DisplayFormat(NullDisplayText = "No grade")]
    public Grade? Grade { get; set; }
    public Course Course { get; set; } = default!;
    public Student Student { get; set; } = default!;
}
