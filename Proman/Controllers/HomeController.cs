using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Proman.Models;
using Proman.Services;

namespace Proman.Controllers
{
    public class HomeController : Controller
    {
        private IPerson _personRepo;
        private IProject _projectRepo;
        private IRole _roleRepo;
        private IProjectRole _projectRoleRepo;

        public HomeController(IRole roleRepo, IPerson personRepo, IProject projectRepo, IProjectRole projectRoleRepo)
        {
            _personRepo = personRepo;
            _projectRepo = projectRepo;
            _roleRepo = roleRepo;
            _projectRoleRepo = projectRoleRepo;
        }
        public IActionResult Index()
        {
            var people = _personRepo.ReadAll();

            return View(people);
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Person([Bind(Prefix = "id")]int id)
        {
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
