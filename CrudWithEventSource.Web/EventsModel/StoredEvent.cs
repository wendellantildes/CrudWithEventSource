using System;
using System.ComponentModel.DataAnnotations;

namespace CrudWithEventSource.Web.EventsModel
{
    public class StoredEvent
    {
        public StoredEvent(int aggregateNumber, string aggregateId, string aggregateIdType, string data, string action, DateTime creationDate, string user)
        {
            Id = Guid.NewGuid();
            AggregateNumber = aggregateNumber;
            AggregateId = aggregateId;
            AggregateIdType = aggregateIdType;
            Data = data;
            Action = action;
            CreationDate = creationDate;
            User = user;
        }

        [Key]
        public Guid Id { get; private set; }

        [Required]
        public int AggregateNumber { get; private set; } //or table name: see AggregationsNumber

        [Required]
        public string AggregateId { get; private set; } //better as a Guid

        [Required]
        public string AggregateIdType { get; private set; } //not necessary if all entities have the Id as a Guid

        [Required]
        public string Data { get; private set; }

        [Required]
        public string Action { get; private set; }

        [Required]
        public DateTime CreationDate { get; private set; }

        [Required]
        public string User { get; private set; }
    }
}
