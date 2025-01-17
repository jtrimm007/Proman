﻿namespace Proman.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Proman.Models.DBEntities;
    using Proman.Models.ViewModels;
    using Proman.Services;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Person controller routes all the CRUD opperation for person objects
    /// </summary>
    public class PersonController : Controller
    {
        /// <summary>
        /// Defines the _personRepo
        /// </summary>
        private IPerson _personRepo;

        /// <summary>
        /// Defines the _projectRepo
        /// </summary>
        private IProject _projectRepo;

        /// <summary>
        /// Defines the _roleRepo
        /// </summary>
        private IRole _roleRepo;

        /// <summary>
        /// Defines the _projectRoleRepo
        /// </summary>
        private IProjectRole _projectRoleRepo;

        /// <summary>
        /// Initializes a new instance of the <see cref="PersonController"/> class.
        /// </summary>
        /// <param name="person"></param>
        /// <param name="projectRepo">The projectRepo<see cref="IProject"/></param>
        /// <param name="roleRepo">The roleRepo<see cref="IRole"/></param>
        /// <param name="projectRoleRepo">The projectRoleRepo<see cref="IProjectRole"/></param>
        public PersonController(IPerson person, IProject projectRepo, IRole roleRepo, IProjectRole projectRoleRepo)
        {
            _personRepo = person;
            _projectRepo = projectRepo;
            _roleRepo = roleRepo;
            _projectRoleRepo = projectRoleRepo;
        }

        /// <summary>
        /// The PersonReport displays all the people and the projects they are assigned to, with the associated roles, plus hourly rate.
        /// </summary>
        /// <returns>The <see cref="IActionResult"/></returns>
        public IActionResult PersonReport()
        {
            //Read in all the repos for manipulation.
            var projects = _projectRepo.ReadAll().ToList();
            var people = _personRepo.ReadAll().ToList();
            var roles = _roleRepo.ReadAll().ToList();
            var projectRoles = _projectRoleRepo.ReadAll().ToList();


            //Instantiate and declaire ProjectReport VM
            PersonReportVM model = new PersonReportVM
            {
                Projects = _projectRepo.ReadAll().ToList(),
                Person = _personRepo.ReadAll().ToList(),
                Roles = _roleRepo.ReadAll().ToList(),
                ProjectRoles = _projectRoleRepo.ReadAll().ToList(),
                HourlyTotal = new Dictionary<Project, decimal>(),
                ListOfProjectsAndPeople = new Dictionary<string, Dictionary<Project, Dictionary<Role, decimal>>>()
            };


            //Loop through each project
            foreach (var pro in model.Person)
            {
                List<int> projectsList = new List<int>();
                projectsList = _projectRoleRepo.SelectProjectsAssignedToPeople(pro.Id);
                Dictionary<Project, Dictionary<Role, decimal>> projectAndRole = new Dictionary<Project, Dictionary<Role, decimal>>();

                //Loop through each person
                foreach (var p in projectsList)
                {
                    //Get a person
                    var projectAssigned = _projectRepo.Read(p);

                    //Get all the project role by user id and project id
                    List<int> roleIds = _projectRoleRepo.SelectRoleOnProjectByPersonId(p, pro.Id);

                    //Create a list to store roles and hourly rate relationships
                    Dictionary<Role, decimal> assignedRoles = new Dictionary<Role, decimal>();

                    //Loop through each role
                    foreach (var role in roleIds)
                    {
                        //Get each hourly rate for each project, person, and role. Then add it to a dictionary. 
                        var readRoles = _roleRepo.Read(role);
                        var hourly = _projectRoleRepo.HourlyRate(pro.Id, p, role);

                        //If the role does not come back null, add it to the list.
                        if(readRoles != null)
                        {
                             assignedRoles.Add(readRoles, hourly);
                        }
                    }


                    //Check to see if the project has been added
                    if (!projectAndRole.ContainsKey(projectAssigned))
                    {
                        //Add the user and roles if they have not been added
                        projectAndRole.Add(projectAssigned, assignedRoles);
                    }
                }

                //Define full name
                string fullName = $"{pro.FirstName} {pro.LastName}";

                //Check to see if the person key has been added.
                if(!model.ListOfProjectsAndPeople.ContainsKey(fullName))
                {
                    //Put all the dictionaries together.
                    model.ListOfProjectsAndPeople.Add(fullName, projectAndRole);

                }
            }

            return View(model);
        }

        /// <summary>
        /// This method brings in the person to delete and hands off the information to display in the view.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>An object of the person to delete</returns>
        public IActionResult DeletePerson(int id)
        {
            var personToDelete = _personRepo.Read(id);
            if (personToDelete == null)
            {
                return RedirectToAction("Index", "Home");
            }
            return View(personToDelete);
        }

        /// <summary>
        /// Post method to confirm deleting a person
        /// </summary>
        /// <param name="person"></param>
        /// <returns>Redirects back to the list of people</returns>
        [HttpPost]
        public IActionResult DeletePerson(Person person)
        {
            _personRepo.Delete(person.Id);
            return RedirectToAction("Index", "Person");
        }

        /// <summary>
        /// Set up the routing for adding a person and return a view
        /// </summary>
        /// <returns>a View()</returns>
        public IActionResult AddPerson()
        {
            return View();
        }

        /// <summary>
        /// Gives the details of a spacific person for the view. 
        /// </summary>
        /// <param name="id"></param>
        /// <returns>A View of a person object</returns>
        public IActionResult Details(int id)
        {
            var person = _personRepo.Read(id);

            return View(person);
        }

        /// <summary>
        /// Post logic to add a person object to the person table.
        /// </summary>
        /// <param name="person"></param>
        /// <returns>Upon success, redirects back to person list</returns>
        [HttpPost]
        public IActionResult AddPerson(Person person)
        {
            var checkPerson = _personRepo.Read(person.Id);

            if (checkPerson == null)
            {
                _personRepo.Add(person);
                return RedirectToAction("Index", "Person");
            }
            return View();
        }

        /// <summary>
        /// Pass in the person id to edit and return the person object to the view.
        /// </summary>
        /// <param name="id">The id<see cref="int"/></param>
        /// <returns>A person object <see cref="IActionResult"/></returns>
        public IActionResult Edit(int id)
        {
            var person = _personRepo.Read(id);

            if (person == null)
            {
                return RedirectToAction("Index", "Home");
            }
            return View(person);
        }

        /// <summary>
        /// Post edit method that contains the logic to update a person in the database.
        /// </summary>
        /// <param name="person">The person<see cref="Person"/></param>
        /// <returns>Upon success, redirect to person list <see cref="IActionResult"/></returns>
        [HttpPost]
        public IActionResult Edit(Person person)
        {
            if (ModelState.IsValid)
            {
                _personRepo.Update(person);
                return RedirectToAction("Index", "Person");
            }

            return View(person);
        }

        /// <summary>
        /// The Index list all of the people in the database table person.
        /// </summary>
        /// <returns>The <see cref="IActionResult"/></returns>
        public IActionResult Index()
        {
            var people = _personRepo.ReadAll().OrderBy(s => s.FirstName);

            if(people != null)
            {
                return View(people);
            }

            return View();
        }
    }
}
