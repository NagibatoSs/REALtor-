using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using REALtor1._2.Data.Interfaces;
using REALtor1._2.Data.Models;

namespace REALtor1._2.Data.Repository
{
    public class HouseRepository : IAllHouses
    {
        private readonly DbContent dbContent;
        public HouseRepository(DbContent dbContent)
        {
            this.dbContent = dbContent;
        }
        public IEnumerable<House> Houses => dbContent.House.Include(p => p.Seller);

        public IEnumerable<House> GetAvailableHouses => dbContent.House.Where(h => h.Available).Include(p => p.Seller);
        public void createHouse(House house)
        {
            dbContent.House.Add(house);
            dbContent.SaveChanges();
        }

        public void DeleteHouse(int idd)
        {
            dbContent.House.Remove(new House(){id = idd});
            dbContent.SaveChanges();
        }

        public House getObjectHouse(int houseId) => dbContent.House.FirstOrDefault(n => n.id == houseId);

        public void SaveHouse(House entity)
        {
            if (entity.id == default)
                dbContent.Entry(entity).State = EntityState.Added;
            else
                dbContent.Entry(entity).State = EntityState.Modified;
            dbContent.SaveChanges();
        }
        public IQueryable<House> GetHouse()
        {
            return dbContent.House;
        }
        public House GetByCodeWord(string codeWord)
        {
            return dbContent.House.FirstOrDefault(x => x.CodeWord == codeWord);
        }
    }
}
