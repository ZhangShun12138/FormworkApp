namespace EfInfrastructure.Models;

public class Student
{
    public int ID { get; set; }
    public string LastName { get; set; } = default!;
    public string FirstMidName { get; set; } = default!;
    public DateTime EnrollmentDate { get; set; }
    public ICollection<Enrollment> Enrollments { get; set; } = default!;
}
