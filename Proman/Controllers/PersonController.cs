using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Proman.Models.DBEntities;
using Proman.Services;

namespace Proman.Controllers
{
    public class PersonController : Controller
    {
        private IPerson _personRepo;

        public PersonController(IPerson person)
        {
            _personRepo = person;
        }

        public IActionResult DeletePerson(int id)
        {
            var personToDelete = _personRepo.Read(id);
            if(personToDelete == null)
            {
                return RedirectToAction("Index", "Home");
            }
            return View(personToDelete);
        }
        
        [HttpPost]
        public IActionResult DeletePerson(Person person)
        {
           
                _personRepo.Delete(person.Id);
                return RedirectToAction("Index", "Home");

        }

        public IActionResult AddPerson()
        {

            return View();
        }

        [HttpPost]
        public IActionResult AddPerson(Person person)
        {
            var checkPerson = _personRepo.Read(person.Id);

            if(checkPerson == null)
            {
                _personRepo.Add(person);
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        public IActionResult Edit(int id)
        {
            var person = _personRepo.Read(id);

            if(person == null)
            {
                return RedirectToAction("Index", "Home");
            }
            return View(person);
        }

        [HttpPost]
        public IActionResult Edit(Person person)
        {
            if(ModelState.IsValid)
            {
                _personRepo.Update(person);
                return RedirectToAction("Index", "Home");
            }

            return View(person);
        }
        public IActionResult Index()
        {
            var people = _personRepo.ReadAll();

            return View(people);
        }
    }
}