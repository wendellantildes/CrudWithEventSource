using System;
using System.ComponentModel.DataAnnotations;

namespace CrudWithEventSource.Web.Domain
{
    public class Teacher
    {
        protected Teacher()
        {
           
        }

        public Teacher(string name, string email)
        {
            Guid.NewGuid();
            Name = name;
            Email = email;
        }

        [Key]
        public Guid Id { get; private set; }

        [Required]
        public string Name { get; private set; }

        [Required]
        public string Email { get; private set; }

        public void UpdateEmail(string email)
        {
            Email = email;
        }

        public void UpdateName(string name)
        {
            Name = name;
        }
    }
}
