namespace Proman.Controllers
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
        private IProject _projectRepo;
        private IRole _roleRepo;
        private IProjectRole _projectRoleRepo;

        /// <summary>
        /// Initializes a new instance of the <see cref="PersonController"/> class.
        /// </summary>
        /// <param name="person"></param>
        public PersonController(IPerson person, IProject projectRepo, IRole roleRepo, IProjectRole projectRoleRepo)
        {
            _personRepo = person;
            _projectRepo = projectRepo;
            _roleRepo = roleRepo;
            _projectRoleRepo = projectRoleRepo;
        }

        public IActionResult PersonReport()
        {
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
                //if (!model.HourlyTotal.ContainsKey(pro))
                //{
                //    model.HourlyTotal.Add(pro, testing.Sum());
                //}
                ////Put all the dictionaries together.
                //model.ListOfProjectsAndPeople.Add(pro, personAndRole);


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
            var people = _personRepo.ReadAll();

            return View(people);
        }
    }
}
