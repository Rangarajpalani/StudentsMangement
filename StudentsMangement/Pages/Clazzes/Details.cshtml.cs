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
    public class DetailsModel : PageModel
    {
        private readonly StudentsMangement.Data.StudentsMangementContext _context;

        public DetailsModel(StudentsMangement.Data.StudentsMangementContext context)
        {
            _context = context;
        }

      public Clazz Clazz { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Clazz == null)
            {
                return NotFound();
            }

            var clazz = await _context.Clazz.Include(e => e.Staffs).FirstOrDefaultAsync(m => m.Id == id);
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
    }
}
