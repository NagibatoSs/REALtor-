using REALtor1._2.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace REALtor1._2.Data
{
    public class DataManager
    {
        public IAllHouses Houses { get; set; }
        public IAllPerson People { get; set; }

        public DataManager(IAllHouses housesRepository, IAllPerson peopleRepository)
        {
            Houses = housesRepository;
            People = peopleRepository;
        }
    }
}
