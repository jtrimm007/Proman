namespace Proman.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Proman.Models.DBEntities;
    using Proman.Models.ViewModels;
    using Proman.Services;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Defines the <see cref="ProjectsController" />
    /// </summary>
    public class ProjectsController : Controller
    {
        /// <summary>
        /// Defines the _projectRepo
        /// </summary>
        private IProject _projectRepo;

        /// <summary>
        /// Defines the _personRepo
        /// </summary>
        private IPerson _personRepo;

        /// <summary>
        /// Defines the _roleRepo
        /// </summary>
        private IRole _roleRepo;

        /// <summary>
        /// Defines the _projectRoleRepo
        /// </summary>
        private IProjectRole _projectRoleRepo;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProjectsController"/> class, and injects project, person, role, and projectrole repos.
        /// </summary>
        /// <param name="project">The project<see cref="IProject"/></param>
        /// <param name="person">The person<see cref="IPerson"/></param>
        /// <param name="role">The role<see cref="IRole"/></param>
        /// <param name="projectRole">The projectRole<see cref="IProjectRole"/></param>
        public ProjectsController(IProject project, IPerson person, IRole role, IProjectRole projectRole)
        {
            _projectRepo = project;
            _personRepo = person;
            _roleRepo = role;
            _projectRoleRepo = projectRole;
        }

        /// <summary>
        /// The ProjectReport gathers a list of the projects, people working on the project, and roles that each person has on each project. (See User Stories #7)
        /// </summary>
        /// <returns>The <see cref="IActionResult"/> containing the VM</returns>
        public IActionResult ProjectReport()
        {
            var projects = _projectRepo.ReadAll().ToList();
            var people = _personRepo.ReadAll().ToList();
            var roles = _roleRepo.ReadAll().ToList();
            var projectRoles = _projectRoleRepo.ReadAll().ToList();


            //Instantiate and declaire ProjectReport VM
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



        /// <summary>
        /// The Details method gets the details about a specific project with the project id.
        /// </summary>
        /// <param name="projectId">The projectId<see cref="int"/></param>
        /// <returns>The <see cref="IActionResult"/> returns a view of the VM</returns>
        public IActionResult Details([Bind(Prefix = "id")] int projectId)
        {
            //Read in a project and project roles.
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

            //Loop through each project role
            foreach (var each in projectRole)
            {
                //if the project role id equals the project id passed in, enter.
                if (each.ProjectId == projectId)
                {
                    //Read in the person 
                    var person = _personRepo.Read(each.PersonId);

                    //Add the PR to the viewModel
                    model.ProjectRoles.Add(each);

                    //Make sure we have a person before trying to set the People to assign to project
                    if (person != null)
                    {
                        //Assign person to project
                        model.PeopleAssignedToProject.Add(person);

                    }
                }
            }

            //Now, loop through each of the people assigned to the project
            foreach (var per in model.PeopleAssignedToProject)
            {
                //Define a list for later
                List<Role> roleList = new List<Role>();

                //Loop through each of the PRs
                foreach (var item in model.ProjectRoles)
                {

                    //If we fine a PR person id that matches the people we are looping through, enter.
                    if (per.Id == item.PersonId)
                    {
                        //Get the role name with role id from PR
                        var readRole = _roleRepo.Read(item.RoleId);

                        //Add the role to roleList
                        roleList.Add(readRole);
                    }
                }

                // ----MIGHT NEED TO REMOVE ROLELIST == NULL ----
                //If the roleList is null, add an empty object so it doesn't have a null value.
                if (roleList == null)
                {
                    roleList.Add(new Role());
                    //Add people that a person
                    model.PersonRoles.Add(per, roleList);
                }
                else
                {
                    //Check if the person has already been added
                    if (!model.PersonRoles.ContainsKey(per))
                    {
                        //Add a person and their roles on the project
                        model.PersonRoles.Add(per, roleList);
                    }
                }
            }

            //Set the number of people assigned to the project
            model.NumberOfPeopleAssigned = model.PeopleAssignedToProject.Count;

            return View(model);
        }

        /// <summary>
        /// The AssignPerson, assigns a person to a project with a starting role of Memeber.
        /// </summary>
        /// <param name="id">The id<see cref="int"/></param>
        /// <returns>The <see cref="IActionResult"/> returns the AddPersonToProjectVM</returns>
        public IActionResult AssignPerson(int id)
        {
            //Read stuff from db
            var project = _projectRepo.Read(id);
            var people = _personRepo.ReadAll();
            var projectRole = _projectRoleRepo.ReadAll();

            //Instantiate the VM
            AddPersonToProjectVM model = new AddPersonToProjectVM
            {
                ProjectId = id,
                ProjectName = project.Name,
                PeopleAvailable = new List<Person>(),
                PeopleNotAvailable = new List<Person>()
            };

            //Make sure we have PRs to read
            if (projectRole != null)
            {
                //Loop through each PR
                foreach (var each in projectRole)
                {
                    //Find the people already assigned to the project
                    if (each.ProjectId == model.ProjectId)
                    {
                        //Read in the person
                        var person = _personRepo.Read(each.PersonId);

                        //Add the person to the list of people not available.
                        model.PeopleNotAvailable.Add(person);

                        //Remove the person from the people list for availablity.
                        people.Remove(person);
                    }
                }
            }
            else
            {
                //Loop through the people
                foreach (var person in people)
                {
                    //Read in the person
                    var person1 = _personRepo.Read(person.Id);

                    //Add the person to the people available list.
                    model.PeopleAvailable.Add(person1);
                }
            }

            //Add the rest of the available people.
            foreach (var each in people)
            {
                model.PeopleAvailable.Add(each);
            }


            return View(model);
        }

        /// <summary>
        /// This Assign method contains the post criteria for assigning a person to a project.
        /// </summary>
        /// <param name="personId">The personId<see cref="int"/></param>
        /// <param name="projectId">The projectId<see cref="int"/></param>
        /// <returns>The <see cref="IActionResult"/>, redirects back to the project details page of the project the person was being assigned to.</returns>
        [HttpPost, AutoValidateAntiforgeryToken]
        public IActionResult Assign(int personId, int projectId)
        {
            //Declaire a new project object
            ProjectRole projectRole = new ProjectRole();

            //Read in all the roles
            var roles = _roleRepo.ReadAll();

            //Set the PR person and project ids.
            projectRole.PersonId = personId;
            projectRole.ProjectId = projectId;

            //Loop through the roles to the member role
            foreach (var each in roles)
            {
                if (each.Name.Equals("Member"))
                {
                    //Add the member role id to the PR object
                    projectRole.RoleId = each.Id;
                }
            }

            //Make sure we have done something with our PR
            if (projectRole != null)
            {
                //Create the PR and redirect.
                _projectRoleRepo.Create(projectRole);
                return RedirectToAction("Details", "Projects", new { id = projectRole.ProjectId });
            }

            return View();
        }

        /// <summary>
        /// The AssignRoleToPerson method reads in the person id, and the project id to add the role too.
        /// </summary>
        /// <param name="personId">The personId<see cref="int"/></param>
        /// <param name="projectId">The projectId<see cref="int"/></param>
        /// <returns>The <see cref="IActionResult"/></returns>
        public IActionResult AssignRoleToPerson(int personId, int projectId)
        {
            //Read in all the roles.
            var roles = _roleRepo.ReadAll();

            //Setup a role object.
            Role role = new Role();

            //Read in all the PRs
            var projectRoles = _projectRoleRepo.ReadAll();

            //Declaire lists for available roles and currentUsers.
            List<int> currentUserRoles = new List<int>();
            List<Role> availableRoles = new List<Role>();

            //Read in the specific person with the person id passed in.
            var getPerson = _personRepo.Read(personId);

            //Set a string for the users full name.
            var personName = $"{getPerson.FirstName} {getPerson.LastName}";

            //Read in the specific project with the project id passed in.
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

        /// <summary>
        /// This is AssignRole post, it assigns the role to the database, and redirects
        /// </summary>
        /// <param name="personId">The personId<see cref="int"/></param>
        /// <param name="projectId">The projectId<see cref="int"/></param>
        /// <param name="roleId">The roleId<see cref="int"/></param>
        /// <param name="hourlyRate">The hourlyRate<see cref="decimal"/></param>
        /// <returns>The <see cref="IActionResult"/> redirects to the project details.</returns>
        [HttpPost]
        public IActionResult AssignRole(int personId, int projectId, int roleId, decimal hourlyRate)
        {
            //Declaire a new PR object.
            ProjectRole projectRole = new ProjectRole();

            //Set the properties
            projectRole.PersonId = personId;
            projectRole.ProjectId = projectId;
            projectRole.HourlyRate = hourlyRate;
            projectRole.RoleId = roleId;

            //Create the role in the PR table
            _projectRoleRepo.Create(projectRole);

            //Redirect back to the project details page.
            return RedirectToAction("Details", "Projects", new { id = projectId });
        }

        /// <summary>
        /// The RemoveRoleFromPerson
        /// </summary>
        /// <param name="personId">The personId<see cref="int"/></param>
        /// <param name="projectId">The projectId<see cref="int"/></param>
        /// <returns>The <see cref="IActionResult"/></returns>
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

        /// <summary>
        /// The RemoveRole
        /// </summary>
        /// <param name="personId">The personId<see cref="int"/></param>
        /// <param name="projectId">The projectId<see cref="int"/></param>
        /// <param name="roleId">The roleId<see cref="int"/></param>
        /// <returns>The <see cref="IActionResult"/></returns>
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

        /// <summary>
        /// The DeleteProject
        /// </summary>
        /// <param name="id">The id<see cref="int"/></param>
        /// <returns>The <see cref="IActionResult"/></returns>
        public IActionResult DeleteProject(int id)
        {
            var projectToDelete = _projectRepo.Read(id);
            if (projectToDelete == null)
            {
                return RedirectToAction("Index", "Projects");
            }
            return View(projectToDelete);
        }

        /// <summary>
        /// The DeleteProject
        /// </summary>
        /// <param name="project">The project<see cref="Project"/></param>
        /// <returns>The <see cref="IActionResult"/></returns>
        [HttpPost]
        public IActionResult DeleteProject(Project project)
        {

            _projectRepo.Delete(project.Id);
            return RedirectToAction("Index", "Projects");
        }

        /// <summary>
        /// The AddProject
        /// </summary>
        /// <returns>The <see cref="IActionResult"/></returns>
        public IActionResult AddProject()
        {

            return View();
        }

        /// <summary>
        /// The AddProject
        /// </summary>
        /// <param name="project">The project<see cref="Project"/></param>
        /// <returns>The <see cref="IActionResult"/></returns>
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

        /// <summary>
        /// The Edit
        /// </summary>
        /// <param name="id">The id<see cref="int"/></param>
        /// <returns>The <see cref="IActionResult"/></returns>
        public IActionResult Edit(int id)
        {
            var project = _projectRepo.Read(id);

            if (project == null)
            {
                return RedirectToAction("Index", "Projects");
            }
            return View(project);
        }

        /// <summary>
        /// The Edit
        /// </summary>
        /// <param name="project">The project<see cref="Project"/></param>
        /// <returns>The <see cref="IActionResult"/></returns>
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

        /// <summary>
        /// The Index
        /// </summary>
        /// <returns>The <see cref="IActionResult"/></returns>
        public IActionResult Index()
        {
            var project = _projectRepo.ReadAll();

            return View(project);
        }

        /// <summary>
        /// The RemovePersonFromProject
        /// </summary>
        /// <param name="personId">The personId<see cref="int"/></param>
        /// <param name="projectId">The projectId<see cref="int"/></param>
        /// <returns>The <see cref="IActionResult"/></returns>
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

        /// <summary>
        /// The RemovePerson
        /// </summary>
        /// <param name="userId">The userId<see cref="int"/></param>
        /// <param name="projectId">The projectId<see cref="int"/></param>
        /// <returns>The <see cref="IActionResult"/></returns>
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
