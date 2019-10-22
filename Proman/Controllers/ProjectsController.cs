using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Proman.Models.DBEntities;
using Proman.Services;

namespace Proman.Controllers
{
    public class ProjectsController : Controller
    {
        private IProject _projectRepo;
        private IPerson _personRepo;
        private IRole _roleRepo;
        private IProjectRole _projectRoleRepo;

        public ProjectsController(IProject project, IPerson person, IRole role, IProjectRole projectRole)
        {
            _projectRepo = project;
            _personRepo = person;
            _roleRepo = role;
            _projectRoleRepo = projectRole;
        }

        public IActionResult Details()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Details(Person person)
        {
            var checkProjectPerson = _projectRepo.Read(person.Id);

            if (checkProjectPerson != null)
            {
                _

                _projectRepo.Add(project);
                return RedirectToAction("Index", "Projects");
            }
            return View();
        }

        public IActionResult DeleteProject(int id)
        {
            var projectToDelete = _projectRepo.Read(id);
            if (projectToDelete == null)
            {
                return RedirectToAction("Index", "Projects");
            }
            return View(projectToDelete);
        }

        [HttpPost]
        public IActionResult DeleteProject(Project project)
        {

            _projectRepo.Delete(project.Id);
            return RedirectToAction("Index", "Projects");

        }

        public IActionResult AddProject()
        {

            return View();
        }

        [HttpPost]
        public IActionResult AddProject(Project project)
        {
            var checkProject = _projectRepo.Read(project.Id);

            if (checkProject == null)
            {


                _projectRepo.Add(project);
                return RedirectToAction("Index", "Projects");
            }
            return View();
        }

        public IActionResult Edit(int id)
        {
            var person = _projectRepo.Read(id);

            if (person == null)
            {
                return RedirectToAction("Index", "Projects");
            }
            return View(person);
        }

        [HttpPost]
        public IActionResult Edit(Project project)
        {
            if (ModelState.IsValid)
            {
                _projectRepo.Update(project);
                return RedirectToAction("Index", "Projects");
            }

            return View(project);
        }
        public IActionResult Index()
        {
            var project = _projectRepo.ReadAll();

            return View(project);
        }

    }
}