using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrudWithEventSource.Web.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CrudWithEventSource.Web.Pages.Students
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationContext _context;

        public IndexModel(ApplicationContext context)
        {
            _context = context;
        }

        public List<StudentDto> Students { get; set; } 

        public void OnGet()
        {
            var students = _context.Students.ToList();
            Students = students.Select(s =>
            {
                return new StudentDto
                {
                    Id = s.Id,
                    Name = s.Name
                };
            }).ToList();

        }


        public class StudentDto
        {
            public Guid Id { get; set; }
            public string Name { get; set; }
        }
    }
}
