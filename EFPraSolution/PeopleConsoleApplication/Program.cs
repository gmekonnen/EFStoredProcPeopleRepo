using PeopleConsoleApplication.Dto;
using PeopleConsoleApplication.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeopleConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var repo = new PeopleRepository();

                var personId = repo.InsertPerson(new PersonDto()
                {
                    Name = string.Format("Test - {0}", DateTime.Now.Millisecond),
                    RegistredOn = DateTime.UtcNow
                });

                var savePersonId = personId ?? 0;

                Console.WriteLine(string.Format("New Person ID: {0}", savePersonId));

                Console.ReadKey();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
