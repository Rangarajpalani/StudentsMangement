using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using StudentsMangement.Data;
using StudentsMangement.Models;

namespace StudentsMangement.Pages.Clazzes
{
    public class CreateModel : PageModel
    {
        private readonly StudentsMangement.Data.StudentsMangementContext _context;

        public CreateModel(StudentsMangement.Data.StudentsMangementContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Clazz Clazz { get; set; } = default!;
        public List<SelectListItem> Staffs { get; set; }
        private List<SelectListItem> StaffsList()
        {
            List<SelectListItem> dropStaffs = _context.Staff.Select(X => new SelectListItem
            { Text = X.Name, Value = X.Id.ToString() }).ToList();
            return dropStaffs;
        }

        public IActionResult OnGet()
        {
            this.Staffs = this.StaffsList();
            return Page();
        }

        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync(String[] StaffIds)
        {
            this.Staffs = this.StaffsList();
            if (StaffIds != null)
            {
                ViewData["Message"] = "Selected Staffs:";
                foreach(string StaffId in StaffIds)
                {
                    SelectListItem selectedStaffs = this.Staffs.Find(s => s.Value ==StaffId);
                    selectedStaffs.Selected = true;
                    ViewData["Message"] += "\\n" + selectedStaffs.Text;
                }
            }

            if (!ModelState.IsValid || _context.Clazz == null || Clazz == null)
            {
                return Page();
            }

            _context.Clazz.Add(Clazz);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
