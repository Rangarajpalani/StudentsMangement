using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using StudentsMangement.Data;
using StudentsMangement.Models;

namespace StudentsMangement.Pages.Students
{
    public class DetailsModel : PageModel
    {
        private readonly StudentsMangement.Data.StudentsMangementContext _context;

        public DetailsModel(StudentsMangement.Data.StudentsMangementContext context)
        {
            _context = context;
        }

      public Student Student { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Student == null)
            {
                return NotFound();
            }

            var student = await _context.Student.Include(e =>e.Clazzes).Include(e => e.Courzes).FirstOrDefaultAsync(m => m.Id == id);
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
