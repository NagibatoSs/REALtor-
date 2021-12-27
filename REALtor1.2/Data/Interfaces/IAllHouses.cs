using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using REALtor1._2.Data.Models;

namespace REALtor1._2.Data.Interfaces
{
    public interface IAllHouses
    {
        IEnumerable<House> Houses { get; }
        IEnumerable<House> GetAvailableHouses { get; }
        public void createHouse(House house);
        House getObjectHouse(int id);
        void SaveHouse(House entity);
        void DeleteHouse(int id);
        public IQueryable<House> GetHouse();
        public House GetByCodeWord(string codeWord);
    }
}
