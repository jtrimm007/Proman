using Microsoft.AspNetCore.Mvc;
using Proman.Models.DBEntities;
using Proman.Models.ViewModels;
using Proman.Services;
using System;
using System.Collections.Generic;
using System.Linq;

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

        public IActionResult ProjectReport()
        {
            var projects = _projectRepo.ReadAll().ToList();
            var people = _personRepo.ReadAll().ToList();
            var roles = _roleRepo.ReadAll().ToList();
            var projectRoles = _projectRoleRepo.ReadAll().ToList();

            

            ProjectReportVM model = new ProjectReportVM
            {
                Projects = _projectRepo.ReadAll().ToList(),
                Person = _personRepo.ReadAll().ToList(),
                Roles = _roleRepo.ReadAll().ToList(),
                ProjectRoles = _projectRoleRepo.ReadAll().ToList(),
                HourlyTotal = new Dictionary<Project, decimal>(),
                Test = 0,
                ListOfProjectsAndPeople = new Dictionary<Project, Dictionary<string, Dictionary<Role, decimal>>>()
            };


            //Loop through each project
            foreach (var pro in model.Projects)
            {
                List<int> persons = new List<int>();
                persons = _projectRoleRepo.SelectPeopleOnProject(pro.Id);
                Dictionary<string, Dictionary<Role, decimal>> personAndRole = new Dictionary<string, Dictionary<Role, decimal>>();
                //testing
                List<decimal> testing = new List<decimal>();

                //Loop through each person
                foreach (var p in persons)
                {
                    //Get a person
                    var personAssigned = _personRepo.Read(p);

                    //Use string interpulation to create the name
                    var name = $"{personAssigned.FirstName} {personAssigned.LastName}";
                    //List<string> peopleOnProject = _personRepo.SelectAllPeopleById(p);
 
                    //Get all the project role by user id and project id
                    List<int> roleIds = _projectRoleRepo.SelectRoleOnProjectByPersonId(pro.Id, p);

                    //Create a list to store roles and hourly rate relationships
                    Dictionary<Role, decimal> assignedRoles = new Dictionary<Role, decimal>();


                    //Loop through each role
                    foreach (var role in roleIds)
                    {
                        //Get each hourly rate for each project, person, and role. Then add it to a dictionary. 
                        var readRoles = _roleRepo.Read(role);
                        var hourly = _projectRoleRepo.HourlyRate(p, pro.Id, role);
                        assignedRoles.Add(readRoles, hourly);

                        //Testing total hourly rates
                        testing.Add(hourly);

                    }




                    //Check to see if the user has been added
                    if (!personAndRole.ContainsKey(name))
                    {
                        //Add the user and roles if they have not been added
                        personAndRole.Add(name, assignedRoles);
                    }

                    
                }
                //Testing
                if (!model.HourlyTotal.ContainsKey(pro))
                {
                    model.HourlyTotal.Add(pro, testing.Sum());
                }
                //Put all the dictionaries together.
                model.ListOfProjectsAndPeople.Add(pro, personAndRole);

                
            }

            return View(model);
        }

        public IActionResult Details([Bind(Prefix = "id")] int projectId)
        {
            var proName = _projectRepo.Read(projectId);
            var projectRole = _projectRoleRepo.ReadAll();

            ProjectDetailsVM model = new ProjectDetailsVM
            {
                ProjectId = projectId,
                Name = proName.Name,
                StartDate = proName.StartDate,
                DueDate = proName.DueDate,
                DaysLeft = (proName.DueDate - DateTime.Today).TotalDays,
                PeopleAssignedToProject = new List<Person>(),
                NumberOfPeopleAssigned = 0,
                ProjectRoles = new List<ProjectRole>(),
                PersonRoles = new Dictionary<Person, List<Role>>()
            };

            foreach (var each in projectRole)
            {
                if (each.ProjectId == projectId)
                {
                    var person = _personRepo.Read(each.PersonId);
                    model.ProjectRoles.Add(each);
                    if (person != null)
                    {
                        model.PeopleAssignedToProject.Add(person);

                    }
                }
            }
            foreach (var per in model.PeopleAssignedToProject)
            {
                List<Role> roleList = new List<Role>();

                foreach (var item in model.ProjectRoles)
                {


                    if (per.Id == item.PersonId)
                    {
                        var readRole = _roleRepo.Read(item.RoleId);
                        roleList.Add(readRole);
                    }
                }
                if (roleList == null)
                {
                    roleList.Add(new Role());
                    model.PersonRoles.Add(per, roleList);
                }
                else
                {
                    if (!model.PersonRoles.ContainsKey(per))
                    {
                        model.PersonRoles.Add(per, roleList);

                    }
                }

            }

            model.NumberOfPeopleAssigned = model.PeopleAssignedToProject.Count;
            return View(model);
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

            if (projectRole != null)
            {
                foreach (var each in projectRole)
                {
                    if (each.ProjectId == model.ProjectId)
                    {
                        var person = _personRepo.Read(each.PersonId);
                        model.PeopleNotAvailable.Add(person);

                        people.Remove(person);
                    }

                }


            }
            else
            {
                foreach (var person in people)
                {
                    var person1 = _personRepo.Read(person.Id);
                    model.PeopleAvailable.Add(person1);
                }
            }

            foreach (var each in people)
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

            foreach (var each in roles)
            {
                if (each.Name.Equals("Member"))
                {
                    projectRole.RoleId = each.Id;
                }
            }


            if (projectRole != null)
            {
                _projectRoleRepo.Create(projectRole);
                return RedirectToAction("Details", "Projects", new { id = projectRole.ProjectId });
            }


            return View();
        }

        public IActionResult AssignRoleToPerson(int personId, int projectId)
        {
            var roles = _roleRepo.ReadAll();
            Role role = new Role();
            var projectRoles = _projectRoleRepo.ReadAll();

            List<int> currentUserRoles = new List<int>();
            List<Role> availableRoles = new List<Role>();

            var getPerson = _personRepo.Read(personId);
            var personName = $"{getPerson.FirstName} {getPerson.LastName}";
            var getProject = _projectRepo.Read(projectId);

            //Get all of the users current roles for the project
            foreach (var each in projectRoles)
            {
                if (each.PersonId == personId && each.ProjectId == projectId)
                {
                    currentUserRoles.Add(each.RoleId);
                }
            }


            //Remove all the roles the user currently have from list of available roles
            foreach (var item in roles)
            {
                if (!currentUserRoles.Exists(x => x == item.Id))
                {
                    availableRoles.Add(item);
                }

            }


            AssignRoleToPersonVM model = new AssignRoleToPersonVM
            {
                Roles = availableRoles,
                HourlyRate = 8,
                PersonId = personId,
                PersonName = personName,
                ProjectId = projectId,
                ProjectName = getProject.Name

            };
            return View(model);
        }

        [HttpPost]
        public IActionResult AssignRole(int personId, int projectId, int roleId, decimal hourlyRate)
        {
            ProjectRole projectRole = new ProjectRole();


            projectRole.PersonId = personId;
            projectRole.ProjectId = projectId;
            projectRole.HourlyRate = hourlyRate;
            projectRole.RoleId = roleId;

            _projectRoleRepo.Create(projectRole);

            return RedirectToAction("Details", "Projects", new { id = projectId });
        }

        public IActionResult RemoveRoleFromPerson(int personId, int projectId)
        {
            var projectRoles = _projectRoleRepo.ReadAll();
            var person = _personRepo.Read(personId);
            var project = _projectRepo.Read(projectId);

            RemoveRoleVM model = new RemoveRoleVM
            {
                PersonId = personId,
                PersonName = $"{person.FirstName} {person.LastName}",
                ProjectId = projectId,
                ProjectName = project.Name,
                ProjectRoles = new List<ProjectRole>(),
                UserRoles = new List<Role>()
            };


            foreach (var each in projectRoles)
            {
                if (each.ProjectId == projectId && each.PersonId == personId)
                {
                    var role = _roleRepo.Read(each.RoleId);
                    model.UserRoles.Add(role);
                }
            }

            return View(model);
        }

        [HttpPost]
        public IActionResult RemoveRole(int personId, int projectId, int roleId)
        {
            var projectRoles = _projectRoleRepo.ReadAll();

            foreach (var role in projectRoles)
            {
                if (role.PersonId == personId && role.ProjectId == projectId && role.RoleId == roleId)
                {
                    _projectRoleRepo.Delete(role.Id);
                    return RedirectToAction("Details", "Projects", new { id = projectId });
                }
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

        public IActionResult RemovePersonFromProject(int personId, int projectId)
        {
            var projectRoles = _projectRoleRepo.ReadAll();
            var person = _personRepo.Read(personId);
            var projectName = _projectRepo.Read(projectId);

            RemovePersonProjectRoleVM model = new RemovePersonProjectRoleVM
            {
                UserName = $"{person.FirstName} {person.LastName}",
                UserId = personId,
                ProjectName = projectName.Name,
                ProjectId = projectId,
                ProjectRoleId = new List<ProjectRole>(),
                UserRoles = new List<Role>()
            };


            foreach (var pr in projectRoles)
            {
                if (pr.ProjectId == projectId && pr.PersonId == personId)
                {
                    model.ProjectRoleId.Add(pr);
                }
            }

            foreach (var each in model.ProjectRoleId)
            {
                var readRoles = _roleRepo.Read(each.RoleId);

                model.UserRoles.Add(readRoles);

            }
            return View(model);
        }

        [HttpPost]
        public IActionResult RemovePerson(int userId, int projectId)
        {
            var projectRole = _projectRoleRepo.ReadAll();

            foreach (var each in projectRole)
            {
                if (each.ProjectId == projectId && each.PersonId == userId)
                {
                    _projectRoleRepo.Delete(each.Id);
                    //return RedirectToAction("Details", "Projects", new { id = projectId });
                }
            }

            return RedirectToAction("Details", "Projects", new { id = projectId });
        }

    }
}