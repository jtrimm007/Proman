namespace Proman.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Proman.Models.DBEntities;
    using Proman.Services;

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
        /// Initializes a new instance of the <see cref="PersonController"/> class.
        /// </summary>
        /// <param name="person"></param>
        public PersonController(IPerson person)
        {
            _personRepo = person;
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
