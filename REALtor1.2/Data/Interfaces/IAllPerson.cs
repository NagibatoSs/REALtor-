using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using REALtor1._2.Data.Models;

namespace REALtor1._2.Data.Interfaces
{
    public interface IAllPerson
    {
        IEnumerable<Person> AllPeople { get; }
        void createPerson(Person person);
        void SavePerson(Person entity);
        void DeletePerson(int id);
        
    }
}
