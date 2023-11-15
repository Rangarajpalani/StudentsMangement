using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using StudentsMangement.Data;
using StudentsMangement.Models;

namespace StudentsMangement.Pages.Courzes
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
            return Page();
        }

        [BindProperty]
        public Courze Courze { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Courze == null || Courze == null)
            {
                return Page();
            }

            _context.Courze.Add(Courze);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
