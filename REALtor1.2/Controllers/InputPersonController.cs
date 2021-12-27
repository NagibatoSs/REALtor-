using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using REALtor1._2.Data.Interfaces;
using REALtor1._2.Data.Models;

namespace REALtor1._2.Controllers
{
    public class InputPersonController:Controller
    {
        private readonly IAllPerson allPerson;
        public InputPersonController(IAllPerson allPerson)
        {
            this.allPerson = allPerson;
        }
        public IActionResult Checkout()
            {
            return View();
            }
        [HttpPost]
        public IActionResult Checkout(Person person)
        {
            if (ModelState.IsValid)
            {
                allPerson.createPerson(person);
                return RedirectToAction("Complete");
            }
            return View();
        }
        public IActionResult Complete()
        {
            ViewBag.Message = "Готово";
            return View();
        }
    }
}
