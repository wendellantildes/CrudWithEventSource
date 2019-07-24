using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrudWithEventSource.Web.Data;
using CrudWithEventSource.Web.Domain;
using CrudWithEventSource.Web.EventsModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CrudWithEventSource.Web.Pages.Teachers
{
    public class HistoryModel : PageModel
    {
        public List<TeacherHistoryDto> Modifications { get; set; }

        private readonly ApplicationContext _context;

        public HistoryModel(ApplicationContext context)
        {
            _context = context;
        }

        public void OnGet(Guid id)
        {
            var storedEvents = _context.StoredEvents.Where(x => x.AggregateNumber == (int)AggregationsNumber.Teacher &&
             x.AggregateId == id.ToString()).OrderByDescending(x => x.CreationDate).ToList();
            Modifications = storedEvents.Select(se =>
            {
                var teacher = Newtonsoft.Json.JsonConvert.DeserializeObject<Teacher>(se.Data);
                return new TeacherHistoryDto
                {
                    Name = teacher.Name,
                    Email = teacher.Email,
                    Action = se.Action,
                    CreationDate = se.CreationDate,
                    User = se.User
                };
            }).ToList();
        }

        public class TeacherHistoryDto
        {
            public string Name { get; set; }

            public string Email { get; set; }

            public string Action { get; set; }

            public DateTime CreationDate { get; set; }

            public string User { get; set; }
        }
    }
}
