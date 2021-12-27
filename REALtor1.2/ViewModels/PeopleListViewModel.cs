using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using REALtor1._2.Data.Models;

namespace REALtor1._2.ViewModels
{
    public class PeopleListViewModel
    {
        public IEnumerable<Person> getAllPeople { get; set; }
    }
}
