using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Proman.Models;
using Proman.Models.ViewModels;
using Proman.Services;

namespace Proman.Controllers
{
    /// <summary>
    /// Home Controller routes the index page with "home".
    /// </summary>
    public class HomeController : Controller
    {
        /// <summary>
        /// Define repos to inject
        /// </summary>
        private IPerson _personRepo;
        private IProject _projectRepo;
        private IRole _roleRepo;
        private IProjectRole _projectRoleRepo;

        /// <summary>
        /// Home constructer the injects the role, person, project, and role repos. 
        /// </summary>
        /// <param name="roleRepo"></param>
        /// <param name="personRepo"></param>
        /// <param name="projectRepo"></param>
        /// <param name="projectRoleRepo"></param>
        public HomeController(IRole roleRepo, IPerson personRepo, IProject projectRepo, IProjectRole projectRoleRepo)
        {
            _personRepo = personRepo;
            _projectRepo = projectRepo;
            _roleRepo = roleRepo;
            _projectRoleRepo = projectRoleRepo;
        }

        /// <summary>
        /// Index is the home page of the application, return the model that contains totals for number of people, projects, and roles.
        /// </summary>
        /// <returns>HomePageVM model</returns>
        public IActionResult Index()
        {
            var numberOfPeople = _personRepo.ReadAll().Count;
            var numberOfProjects = _projectRepo.ReadAll().Count;
            var numberOfRoles = _roleRepo.ReadAll().Count;

            //Instantiate the VM
            HomePageVM model = new HomePageVM
            {
                NumberOfPeople = numberOfPeople,
                NumberOfProjects = numberOfProjects,
                NumberOfRoles = numberOfRoles
            };

            //return the homepagevm
            return View(model);
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
