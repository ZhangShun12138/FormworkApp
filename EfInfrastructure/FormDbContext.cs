using EfInfrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace EfInfrastructure;

public class FormDbContext : DbContext
{
    public FormDbContext(DbContextOptions<FormDbContext> options)
            : base(options)
    {
    }

    public DbSet<Student> Student { get; set; } = default!;
}
