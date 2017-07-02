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
        public virtual int? InsertPerson(Person personEntity)
        {
            int? personId = default(int?);

            if (personEntity != null)
            {
                var sqlParams = new List<SqlParameter>();

                var personIdOutputParam = new SqlParameter()
                {
                    Direction = System.Data.ParameterDirection.Output,
                    ParameterName = "@personId",
                    Value = 0,
                    DbType = System.Data.DbType.Int32
                };

                sqlParams.Add(personIdOutputParam);

                sqlParams.Add(new SqlParameter()
                {
                    ParameterName = "@personName",
                    Value = personEntity.Name,
                   
                });

                sqlParams.Add(new SqlParameter()
                {
                    ParameterName = "@registredOn",
                    Value = personEntity.RegistredOn,
                   
                });

               
                
                    var commandText = "exec [dbo].[InsertPerson] @personName, @registredOn, @personId OUTPUT";
                    var result = this.Database.ExecuteSqlCommand(commandText, sqlParams.ToArray());

                    int newPersonId = 0;

                    if (int.TryParse(personIdOutputParam.Value.ToString(), out newPersonId))
                    {
                        personId = newPersonId;
                    }
                
            }
            return personId;
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
