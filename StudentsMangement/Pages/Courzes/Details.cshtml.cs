using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using StudentsMangement.Data;
using StudentsMangement.Models;

namespace StudentsMangement.Pages.Courzes
{
    public class DetailsModel : PageModel
    {
        private readonly StudentsMangement.Data.StudentsMangementContext _context;

        public DetailsModel(StudentsMangement.Data.StudentsMangementContext context)
        {
            _context = context;
        }

      public Courze Courze { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Courze == null)
            {
                return NotFound();
            }

            var courze = await _context.Courze.FirstOrDefaultAsync(m => m.Id == id);
            if (courze == null)
            {
                return NotFound();
            }
            else 
            {
                Courze = courze;
            }
            return Page();
        }
    }
}
