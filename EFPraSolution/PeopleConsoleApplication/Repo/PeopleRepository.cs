using PeopleConsoleApplication.Dto;
using PeopleConsoleApplication.Repo.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeopleConsoleApplication.Repo
{
    public class PeopleRepository
    {
        public int? InsertPerson(PersonDto personEntity)
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

                using (var context = new PeopleDbContext())
                {
                    var commandText = "exec [dbo].[InsertPerson] @personName, @registredOn, @personId OUTPUT";
                    var result = context.Database.ExecuteSqlCommand(commandText, sqlParams.ToArray());

                    int newPersonId = 0;

                    if (int.TryParse(personIdOutputParam.Value.ToString(), out newPersonId))
                    {
                        personId = newPersonId;
                    }
                }
            }
            return personId;
        }


    }
}
