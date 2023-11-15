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

namespace StudentsMangement.Pages.Clazzes
{
    public class EditModel : PageModel
    {
        private readonly StudentsMangement.Data.StudentsMangementContext _context;

        public EditModel(StudentsMangement.Data.StudentsMangementContext context)
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

            var clazz =  await _context.Clazz.FirstOrDefaultAsync(m => m.Id == id);
            if (clazz == null)
            {
                return NotFound();
            }
            Clazz = clazz;
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

            _context.Attach(Clazz).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClazzExists(Clazz.Id))
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

        private bool ClazzExists(int id)
        {
          return (_context.Clazz?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
