using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Proman.Models.DBEntities;
using Proman.Models.ViewModels;
using Proman.Services;

namespace Proman.Controllers
{
    public class ProjectsController : Controller
    {
        private IProject _projectRepo;
        private IPerson _personRepo;
        private IRole _roleRepo;
        private IProjectRole _projectRoleRepo;

        private ICollection<Person> PeopleFree { get; set; }

        public ProjectsController(IProject project, IPerson person, IRole role, IProjectRole projectRole)
        {
            _projectRepo = project;
            _personRepo = person;
            _roleRepo = role;
            _projectRoleRepo = projectRole;

        }

        public IActionResult Details([Bind(Prefix="id")] int projectId)
        {
            var proName = _projectRepo.Read(projectId);
            var projectRole = _projectRoleRepo.ReadAll();

            foreach(var each in projectRole)
            {
                if(each.ProjectId == projectId)
                {
                    var person = _personRepo.Read(each.PersonId);
                    if(person != null)
                    {
                        proName.PeopleAssignedToProject.Add(person);

                    }
                }
            }

            return View(proName);
        }

        public IActionResult AssignPerson(int id)
        {
            var project = _projectRepo.Read(id);
            var people = _personRepo.ReadAll();
            var projectRole = _projectRoleRepo.ReadAll();


            AddPersonToProjectVM model = new AddPersonToProjectVM
            {
                ProjectId = id,
                ProjectName = project.Name,
                PeopleAvailable = new List<Person>(),
                PeopleNotAvailable = new List<Person>()
            };

            if(projectRole != null)
            {
                foreach(var each in projectRole)
                {
                    if(each.ProjectId == model.ProjectId)
                    {
                        var person = _personRepo.Read(each.PersonId);
                        model.PeopleNotAvailable.Add(person);

                        people.Remove(person);
                    }

                }


            }
            else
            {
                foreach(var person in people)
                {
                    var person1 = _personRepo.Read(person.Id);
                    model.PeopleAvailable.Add(person1);
                }
            }

            foreach(var each in people)
            {
                model.PeopleAvailable.Add(each);
            }

            
            return View(model);
        }

        [HttpPost, AutoValidateAntiforgeryToken]
        public IActionResult Assign(int personId, int projectId)
        {
            ProjectRole projectRole = new ProjectRole();
            var roles = _roleRepo.ReadAll();

            projectRole.PersonId = personId;
            projectRole.ProjectId = projectId;

            foreach(var each in roles)
            {
                if(each.Name.Equals("Member"))
                {
                    projectRole.RoleId = each.Id;
                }
            }


            if(projectRole != null)
            {
                _projectRoleRepo.Create(projectRole);
                return RedirectToAction("Details", "Projects", new { id = projectRole.ProjectId });
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
            var project = _projectRepo.Read(id);

            if (project == null)
            {
                return RedirectToAction("Index", "Projects");
            }
            return View(project);
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