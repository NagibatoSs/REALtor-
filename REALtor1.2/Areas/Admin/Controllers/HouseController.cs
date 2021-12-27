using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting.Internal;
using REALtor1._2.Data;
using REALtor1._2.Data.Models;
using Microsoft.AspNetCore.Hosting;
using REALtor1._2.Data.Interfaces;
using REALtor1._2.ViewModels;

namespace REALtor1._2.Areas.Admin.Controllers
{

    [Area("Admin")]
    public class HouseController : Controller
    {
        private readonly DataManager dataManager;
        public HouseController(DataManager dataManager)
        {
            this.dataManager = dataManager;

        }
        public ViewResult ListHouses()
        {
            ViewBag.Title = "Поиск";
            HousesListViewModel houses = new HousesListViewModel();
            houses.getAllHouses = dataManager.Houses.Houses;
            return View(houses);
        }
        public ViewResult MainView()
        {
            ViewBag.Title = "Главная страница";
            return View();
        }
        public IActionResult Edit(int id)
        {
            var entity = id == default ? new House() : dataManager.Houses.getObjectHouse(id);
            return View(entity);
        }
        [HttpPost]
        public IActionResult Edit(House model, IFormFile imgFile)
        {
            if (ModelState.IsValid)
            {
                dataManager.Houses.SaveHouse(model);
                return RedirectToAction(nameof(HomeController.Index), nameof(HomeController).Replace("Controller",""));
            }
            return View(model);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            dataManager.Houses.DeleteHouse(id);
            return RedirectToAction(nameof(HomeController.Index), nameof(HomeController).Replace("Controller",""));
        }
    }
}
