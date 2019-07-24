using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrudWithEventSource.Web.Data;
using CrudWithEventSource.Web.Domain;
using CrudWithEventSource.Web.EventsModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CrudWithEventSource.Web.Pages.Students
{
    public class HistoryModel : PageModel
    {
        public List<StudentHistoryDto> Modifications { get; set; }

        private readonly ApplicationContext _context;

        public HistoryModel(ApplicationContext context)
        {
            _context = context;
        }

        public void OnGet(Guid id)
        {
            var storedEvents = _context.StoredEvents.Where(x => x.AggregateNumber == (int)AggregationsNumber.Student &&
             x.AggregateId == id.ToString()).OrderByDescending(x => x.CreationDate).ToList();
            Modifications = storedEvents.Select(se =>
            {
                var student = Newtonsoft.Json.JsonConvert.DeserializeObject<Student>(se.Data);
                return new StudentHistoryDto
                {
                    Name = student.Name,
                    IdentificationNumber = student.IdentificationNumber,
                    Action = se.Action,
                    CreationDate = se.CreationDate,
                    User = se.User
                };
            }).ToList();
        }

        public class StudentHistoryDto
        {
            public string Name { get; set; }

            public string IdentificationNumber { get; set; }

            public string Action { get; set; }

            public DateTime CreationDate { get; set; }

            public string User { get; set; }
        }
    }
}
