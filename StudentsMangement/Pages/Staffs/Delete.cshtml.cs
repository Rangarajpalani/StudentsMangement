﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using StudentsMangement.Data;
using StudentsMangement.Models;

namespace StudentsMangement.Pages.Staffs
{
    public class DeleteModel : PageModel
    {
        private readonly StudentsMangement.Data.StudentsMangementContext _context;

        public DeleteModel(StudentsMangement.Data.StudentsMangementContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Staff Staff { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Staff == null)
            {
                return NotFound();
            }

            var staff = await _context.Staff.FirstOrDefaultAsync(m => m.Id == id);

            if (staff == null)
            {
                return NotFound();
            }
            else 
            {
                Staff = staff;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Staff == null)
            {
                return NotFound();
            }
            var staff = await _context.Staff.FindAsync(id);

            if (staff != null)
            {
                Staff = staff;
                _context.Staff.Remove(Staff);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
