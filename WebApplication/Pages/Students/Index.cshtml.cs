using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EfInfrastructure;
using Domain.Entitys;

namespace WebApplication.Pages.Students
{
    public class IndexModel : PageModel
    {
        private readonly EfInfrastructure.FormDbContext _context;

        public IndexModel(EfInfrastructure.FormDbContext context)
        {
            _context = context;
        }

        public IList<Student> Students { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Students = await _context.Students.ToListAsync();
        }
    }
}
