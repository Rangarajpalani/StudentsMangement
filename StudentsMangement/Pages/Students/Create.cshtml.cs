using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using StudentsMangement.Data;
using StudentsMangement.Models;

namespace StudentsMangement.Pages.Students
{
    public class CreateModel : PageModel
    {
        private readonly StudentsMangement.Data.StudentsMangementContext _context;

        public CreateModel(StudentsMangement.Data.StudentsMangementContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["CourzesId"] = new SelectList(_context.Set<Courze>(), "Id", "Course");
            ViewData["ClazzesId"] = new SelectList(_context.Set<Clazz>(), "Id", "Section");
            return Page();
        }

        [BindProperty]
        public Student Student { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Student == null || Student == null)
            {
                return Page();
            }

            _context.Student.Add(Student);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
