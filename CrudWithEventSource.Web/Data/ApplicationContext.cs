using System;
using CrudWithEventSource.Web.Domain;
using CrudWithEventSource.Web.EventsModel;
using Microsoft.EntityFrameworkCore;

namespace CrudWithEventSource.Web.Data
{
    public class ApplicationContext : DbContext
    {

        public ApplicationContext(DbContextOptions options) : base(options)
        {

        }

        public ApplicationContext() : base()
        {

        }

        public DbSet<Student> Students { get; set; }
        public DbSet<StoredEvent> StoredEvents { get; set; } //better in a different context

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
                => optionsBuilder
                    .UseSqlite("Data Source=database.db");
    }
}
