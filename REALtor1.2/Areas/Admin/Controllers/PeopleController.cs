using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using REALtor1._2.Data;
using REALtor1._2.Data.Models;
using REALtor1._2.ViewModels;

namespace REALtor1._2.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PeopleController:Controller
    {
        private readonly DataManager dataManager;
        public PeopleController(DataManager dataManager)
        {
            this.dataManager = dataManager;
        }
        public ViewResult ListPeople()
        {
            ViewBag.Title = "Данные клиентов";
            PeopleListViewModel people = new PeopleListViewModel();
            people.getAllPeople = dataManager.People.AllPeople;
            return View(people);
        }
    }
}
