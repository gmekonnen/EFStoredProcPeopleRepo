namespace PeopleConsoleApplication.Repo.Entities
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class PeopleDbContext : DbContext
    {
        public PeopleDbContext()
            : base("name=PeopleDbContext")
        {
        }

        public virtual DbSet<Person> People { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
