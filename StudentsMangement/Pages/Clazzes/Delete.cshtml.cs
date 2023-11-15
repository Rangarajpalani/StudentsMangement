using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using StudentsMangement.Data;
using StudentsMangement.Models;

namespace StudentsMangement.Pages.Clazzes
{
    public class DeleteModel : PageModel
    {
        private readonly StudentsMangement.Data.StudentsMangementContext _context;

        public DeleteModel(StudentsMangement.Data.StudentsMangementContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Clazz Clazz { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Clazz == null)
            {
                return NotFound();
            }

            var clazz = await _context.Clazz.Include(s =>s.Staffs).FirstOrDefaultAsync(m => m.Id == id);

            if (clazz == null)
            {
                return NotFound();
            }
            else 
            {
                Clazz = clazz;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Clazz == null)
            {
                return NotFound();
            }
            var clazz = await _context.Clazz.FindAsync(id);

            if (clazz != null)
            {
                Clazz = clazz;
                _context.Clazz.Remove(Clazz);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
