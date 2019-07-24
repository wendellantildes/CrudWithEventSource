using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CrudWithEventSource.Web.Domain
{
    public class Address
    {
        public Address(string street, string state)
        {
            Street = street;
            State = state;
        }

        protected Address()
        {
        }

        [Key]
        public Guid Id { get; private set; }

        [ForeignKey("Student")]
        public Guid StudentId { get; private set; }

        [Required]
        public string Street { get; private set; }

        [Required]
        public string State { get; private set; }

        public void UpdateStreet(string street)
        {
            Street = street;
        }

        public void UpdateState(string state)
        {
            State = state;
        }
    }
}
