using PeopleConsoleApplication.Dto;
using PeopleConsoleApplication.Repo.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeopleConsoleApplication.Repo<T> :where T is a calss
{
 private  PeopleDbContext _dbContext;
    public PeopleRepository(PeopleDbContext dbContext){
        this._dbContext=dbContext;//This will be injected using dependencyt injection tool such as Autofac, It will be instantiated ones and reused reused through out
    }
    public class PeopleRepository
    {
        public int? InsertPerson(PersonDto personDto)
        {
           //Move this to PeopleDbContext and add it as one of virual method and call it from here
         int personId=0;
         try
         {
          personId=  _dbContext.InsertPerson(factoryClass.GetPersoEntity(personDto));//This factory calss will do auto mapping between Dto and Entity class
          }
           Catch(Exception ex)
           {
           //Do some thing with it
           }
            return personId;
        }


    }
}
