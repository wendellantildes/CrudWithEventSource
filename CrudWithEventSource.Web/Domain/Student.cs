using System;
using System.ComponentModel.DataAnnotations;

namespace CrudWithEventSource.Web.Domain
{
    public class Student
    {
        protected Student()
        {
           
        }

        public Student(string name, string identificationNumber, Address address)
        {
            Guid.NewGuid();
            Name = name;
            IdentificationNumber = identificationNumber;
            Address = address;
        }

        [Key]
        public Guid Id { get; private set; }

        [Required]
        public string Name { get; private set; }

        [Required]
        public string IdentificationNumber { get; private set; }

        [Required]
        public Address Address { get; private set; }

        public void UpdateIdentificationNumber(string newId)
        {
            IdentificationNumber = newId;
        }

        public void UpdateName(string name)
        {
            Name = name;
        }
    }
}
