using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using CrudWithEventSource.Web.Data;
using CrudWithEventSource.Web.EventSourcing;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CrudWithEventSource.Web.Pages.Students
{
    public class EditModel : PageModel
    {

        private readonly ApplicationContext _context;

        public EditModel(ApplicationContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Guid Id { get; set; }

        [BindProperty]
        public string Name { get; set; }

        [Required]
        [BindProperty]
        [Display(Name = "Identification Number")]
        public string IdentificationNumber { get; set; }

        [Required]
        [BindProperty]
        [Display(Name = "Logged User")]
        public string LoggedUser { get; set; }

        public void OnGet(Guid id)
        {
            var student = _context.Students.Single(x => x.Id == id);
            Name = student.Name;
            IdentificationNumber = student.IdentificationNumber;
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                var student = _context.Students.Single(x => x.Id == Id);
                student.UpdateIdentificationNumber(IdentificationNumber);
                student.UpdateName(Name);
                _context.Students.Update(student);
                if (_context.SaveChanges() > 0)
                {
                    // Suggestion: use a bus to Raise a Event and store it
                    _context.Add(StudentInfoAdapter.DomainToInfo(student, "Update Student", LoggedUser));
                    _context.SaveChanges();
                }

                return RedirectToPage("./Index");
            }
            else
            {
                return Page();
            }
        }
    }
}
