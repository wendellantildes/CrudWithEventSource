using System;
using CrudWithEventSource.Web.Domain;
using CrudWithEventSource.Web.Domain.Students;
using CrudWithEventSource.Web.EventsModel;

namespace CrudWithEventSource.Web.EventSourcing
{
    public class StudentInfoAdapter
    {
        public static StoredEvent DomainToInfo(Student student, string action, string user)
        {
            var data = Newtonsoft.Json.JsonConvert.SerializeObject(student);
            var storedEvent = new StoredEvent((int)AggregationsNumber.Student, $"{student.Id}", $"{student.Id.GetType().ToString()}", data, 
                action, DateTime.Now, user);
            return storedEvent;
        }
    }
}
