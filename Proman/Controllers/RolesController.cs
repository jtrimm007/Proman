using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Proman.Models.DBEntities;
using Proman.Services;

namespace Proman.Controllers
{
    public class RolesController : Controller
    {
        private IRole _roleRepo;
        public RolesController(IRole role)
        {
            _roleRepo = role;
        }
        public IActionResult Index()
        {
            var role = _roleRepo.ReadAll();

            return View(role);
        }

        public IActionResult AddRole()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddRole(Role role)
        {
            var checkPerson = _roleRepo.Read(role.Id);

            if (checkPerson == null)
            {
                _roleRepo.Add(role);
                return RedirectToAction("Index", "Roles");
            }
            return View();
        }

        public IActionResult DeleteRole(int id)
        {
            var roleToDelete = _roleRepo.Read(id);
            if (roleToDelete == null || roleToDelete.Name.Equals("Member"))
            {
                return RedirectToAction("Index", "Roles");
            }
            return View(roleToDelete);
        }

        [HttpPost]
        public IActionResult DeleteRole(Role role)
        {
            var checkPerson = _roleRepo.Read(role.Id);

            if (checkPerson != null || checkPerson.Name != "Member")
            {
                _roleRepo.Delete(role.Id);
                return RedirectToAction("Index", "Roles");
            }
            return View();
        }

        public IActionResult Edit(int id)
        {
            var person = _roleRepo.Read(id);

            if (person == null)
            {
                return RedirectToAction("Index", "Roles");
            }
            return View(person);
        }

        [HttpPost]
        public IActionResult Edit(Role role)
        {
            if (ModelState.IsValid)
            {
                _roleRepo.Update(role);
                return RedirectToAction("Index", "Roles");
            }

            return View(role);
        }
    }
}