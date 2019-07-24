using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using CrudWithEventSource.Web.Data;
using CrudWithEventSource.Web.Domain;
using CrudWithEventSource.Web.Domain.Teachers;
using CrudWithEventSource.Web.EventSourcing;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CrudWithEventSource.Web.Pages.Teachers
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
        [EmailAddress]
        [Required]
        public string Email { get; set; }

        [Required]
        [BindProperty]
        [Display(Name = "Logged User")]
        public string LoggedUser { get; set; }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                var teacher = new Teacher(Name, Email);
                _context.Teachers.Add(teacher);
                if (_context.SaveChanges() > 0)
                {
                    // Suggestion: use a bus to Raise an Event and store it
                    _context.Add(TeacherInfoAdapter.DomainToInfo(teacher, "Add Teacher", LoggedUser));
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
