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
    public class IndexModel : PageModel
    {
        private readonly StudentsMangement.Data.StudentsMangementContext _context;

        public IndexModel(StudentsMangement.Data.StudentsMangementContext context)
        {
            _context = context;
        }

        public IList<Clazz> Clazz { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Clazz != null)
            {
                Clazz = await _context.Clazz.Include(Q => Q.Staffs).ToListAsync();
            }
        }
    }
}
