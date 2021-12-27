using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using REALtor1._2.Data;
using REALtor1._2.Data.Interfaces;
using REALtor1._2.Data.Models;
using REALtor1._2.ViewModels;

namespace REALtor1._2.Controllers
{
    public class HousesController:Controller
    {
        private readonly IAllHouses _allHouses;
        private readonly IAllPerson _allPerson;
        public HousesController(IAllHouses iallHouses,IAllPerson iallPerson)
        {
            _allHouses = iallHouses;
            _allPerson = iallPerson;
        }
        public ViewResult ListHouses()
        {
            ViewBag.Title = "Поиск";
            HousesListViewModel houses = new HousesListViewModel();
            houses.getAllHouses = _allHouses.Houses;
            return View(houses);
        }
        public ViewResult MainView()
        {
            ViewBag.Title = "Главная страница";
            return View();
        }
        public IActionResult Parametrs()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Parametrs(HousesListViewModel housesList)
        {
            HousesListViewModel houses = new HousesListViewModel();
            houses.getAllHouses = _allHouses.Houses;
            var houseFiltr = housesList.getAllHouses.First();
            houses.getAllHouses
                    .Where(n =>
                    n.CountOfRooms == houseFiltr.CountOfRooms
                    && n.coldWater == houseFiltr.coldWater
                    && n.electricity == houseFiltr.electricity
                    && n.gas == houseFiltr.gas
                    && n.hotWater == houseFiltr.hotWater
                    && n.Area == houseFiltr.Area
                    && n.Available == true
                    && n.StatusOfHome == houseFiltr.StatusOfHome
                    && n.Price <= houseFiltr.Price
                    && n.Square <= houseFiltr.Square)
                .Select(n => n);
            return View(houses);
        }

        //[HttpPost]
        //public IActionResult Parametrs(HousesListViewModel houseFiltr)
        //{
        //    HousesListViewModel houses = new HousesListViewModel();
        //    houses.getAllHouses = _allHouses.Houses;
        //    return View(houses);    //
        //}

    }
}
