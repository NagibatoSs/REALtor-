using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using REALtor1._2.Data.Interfaces;
using REALtor1._2.Data.Models;

namespace REALtor1._2.Data.Repository
{
    public class PersonRepository : IAllPerson
    {
        private readonly DbContent dbContent;
        public PersonRepository(DbContent dbContent)
        {
            this.dbContent = dbContent;
        }
        public IEnumerable<Person> AllPeople => dbContent.Person;

        public void createPerson(Person person)
        {
            dbContent.Person.Add(person);
            dbContent.SaveChanges();
        }

        public void DeletePerson(int idd)
        {
            dbContent.House.Remove(new House() { id = idd });
            dbContent.SaveChanges();
        }

        public void SavePerson(Person entity)
        {
            if (entity.id == default)
                dbContent.Entry(entity).State = EntityState.Added;
            else
                dbContent.Entry(entity).State = EntityState.Modified;
            dbContent.SaveChanges();
        }
       
    }
}
