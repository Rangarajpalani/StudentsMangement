using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StudentsMangement.Data;
using StudentsMangement.Models;

namespace StudentsMangement.Pages.Students
{
    public class EditModel : PageModel
    {
        private readonly StudentsMangement.Data.StudentsMangementContext _context;

        public EditModel(StudentsMangement.Data.StudentsMangementContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Student Student { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Student == null)
            {
                return NotFound();
            }
            ViewData["CourzesId"] = new SelectList(_context.Set<Courze>(), "Id", "Course");
            ViewData["ClazzesId"] = new SelectList(_context.Set<Clazz>(), "Id", "Section");

            var student =  await _context.Student.Include(e => e.Clazzes).Include(e => e.Clazzes).FirstOrDefaultAsync(m => m.Id == id);
            if (student == null)
            {
                return NotFound();
            }
            Student = student;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Student).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentExists(Student.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool StudentExists(int id)
        {
          return (_context.Student?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
