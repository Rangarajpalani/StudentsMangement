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
    public class IndexModel : PageModel
    {
        private readonly StudentsMangement.Data.StudentsMangementContext _context;

        public IndexModel(StudentsMangement.Data.StudentsMangementContext context)
        {
            _context = context;
        }

        public IList<Courze> Courze { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Courze != null)
            {
                Courze = await _context.Courze.ToListAsync();
            }
        }
    }
}
