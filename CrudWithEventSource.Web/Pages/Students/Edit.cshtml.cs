using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using CrudWithEventSource.Web.Data;
using CrudWithEventSource.Web.EventSourcing;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

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

        public void OnGet(Guid id)
        {
            var student = _context.Students.Include(x => x.Address).Single(x => x.Id == id);
            Name = student.Name;
            IdentificationNumber = student.IdentificationNumber;
            State = student.Address.State;
            Street = student.Address.Street;
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                var student = _context.Students.Include(x => x.Address).Single(x => x.Id == Id);
                student.UpdateIdentificationNumber(IdentificationNumber);
                student.UpdateName(Name);
                student.Address.UpdateState(State);
                student.Address.UpdateStreet(Street);
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
