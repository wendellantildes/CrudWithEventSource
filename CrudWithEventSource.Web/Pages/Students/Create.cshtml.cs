using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using CrudWithEventSource.Web.Data;
using CrudWithEventSource.Web.Domain;
using CrudWithEventSource.Web.EventSourcing;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CrudWithEventSource.Web.Pages.Students
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationContext _context;

        public CreateModel(ApplicationContext context)
        {
            _context = context;
        }

        [BindProperty]
        [Required]
        public string Name { get; set; }

        [BindProperty]
        [Display(Name = "Identification Number")]
        [Required]
        public string IdentificationNumber { get; set; }

        [BindProperty]
        [Required]
        public string Street { get; set; }

        [BindProperty]
        [Required]
        public string State { get; set; }

        [Required]
        [BindProperty]
        [Display(Name = "Logged User")]
        public string LoggedUser { get; set; }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                var address = new Address(Street, State);
                var student = new Student(Name, IdentificationNumber, address);
                _context.Students.Add(student);
                if (_context.SaveChanges() > 0)
                {
                    // Suggestion: use a bus to Raise an Event and store it
                    _context.Add(StudentInfoAdapter.DomainToInfo(student, "Add Student", LoggedUser));
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
