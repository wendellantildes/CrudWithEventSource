using System;
using CrudWithEventSource.Web.Domain;
using CrudWithEventSource.Web.Domain.Teachers;
using CrudWithEventSource.Web.EventsModel;

namespace CrudWithEventSource.Web.EventSourcing
{
    public class TeacherInfoAdapter
    {
        public static StoredEvent DomainToInfo(Teacher teacher, string action, string user)
        {
            var data = Newtonsoft.Json.JsonConvert.SerializeObject(teacher);
            var storedEvent = new StoredEvent((int)AggregationsNumber.Teacher, $"{teacher.Id}", $"{teacher.Id.GetType().ToString()}", data, 
                action, DateTime.Now, user);
            return storedEvent;
        }
    }
}
