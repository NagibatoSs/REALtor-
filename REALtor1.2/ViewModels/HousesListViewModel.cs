using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using REALtor1._2.Data.Models;

namespace REALtor1._2.ViewModels
{
    public class HousesListViewModel
    {
        public IEnumerable<House> getAllHouses { get; set; }
    }
}
