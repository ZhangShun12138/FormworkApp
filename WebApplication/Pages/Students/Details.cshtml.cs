using Domain.Entitys;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace WebApplication.Pages.Students
{
    public class DetailsModel : PageModel
    {
        private readonly EfInfrastructure.FormDbContext _context;

        public DetailsModel(EfInfrastructure.FormDbContext context)
        {
            _context = context;
        }

        public Student Student { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.Students.FirstOrDefaultAsync(m => m.ID == id);
            if (student == null)
            {
                return NotFound();
            }
            else
            {
                Student = student;
            }
            return Page();
        }
    }
}
