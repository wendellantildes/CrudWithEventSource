using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrudWithEventSource.Web.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CrudWithEventSource.Web.Pages.Teachers
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationContext _context;

        public IndexModel(ApplicationContext context)
        {
            _context = context;
        }

        public List<TeacherDto> Teachers { get; set; }

        public void OnGet()
        {
            var teachers = _context.Teachers.ToList();
            Teachers = teachers.Select(s =>
            {
                return new TeacherDto
                {
                    Id = s.Id,
                    Name = s.Name
                };
            }).ToList();

        }


        public class TeacherDto
        {
            public Guid Id { get; set; }
            public string Name { get; set; }
        }
    }
}
