namespace Proman.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Proman.Models.DBEntities;
    using Proman.Services;
    using System.Linq;

    /// <summary>
    /// Defines the <see cref="RolesController" />
    /// </summary>
    public class RolesController : Controller
    {
        /// <summary>
        /// Defines the _roleRepo
        /// </summary>
        private IRole _roleRepo;

        /// <summary>
        /// Initializes a new instance of the <see cref="RolesController"/> class.
        /// </summary>
        /// <param name="role">The role<see cref="IRole"/></param>
        public RolesController(IRole role)
        {
            _roleRepo = role;
        }

        /// <summary>
        /// The Index
        /// </summary>
        /// <returns>The <see cref="IActionResult"/></returns>
        public IActionResult Index()
        {
            var role = _roleRepo.ReadAll().OrderBy(s => s.Name);

            return View(role);
        }

        /// <summary>
        /// The AddRole
        /// </summary>
        /// <returns>The <see cref="IActionResult"/></returns>
        public IActionResult AddRole()
        {
            return View();
        }

        /// <summary>
        /// The AddRole
        /// </summary>
        /// <param name="role">The role<see cref="Role"/></param>
        /// <returns>The <see cref="IActionResult"/></returns>
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

        /// <summary>
        /// The DeleteRole
        /// </summary>
        /// <param name="id">The id<see cref="int"/></param>
        /// <returns>The <see cref="IActionResult"/></returns>
        public IActionResult DeleteRole(int id)
        {
            var roleToDelete = _roleRepo.Read(id);
            if (roleToDelete == null || roleToDelete.Name.Equals("Member"))
            {
                return RedirectToAction("Index", "Roles");
            }
            return View(roleToDelete);
        }

        /// <summary>
        /// The DeleteRole
        /// </summary>
        /// <param name="role">The role<see cref="Role"/></param>
        /// <returns>The <see cref="IActionResult"/></returns>
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

        /// <summary>
        /// The Edit
        /// </summary>
        /// <param name="id">The id<see cref="int"/></param>
        /// <returns>The <see cref="IActionResult"/></returns>
        public IActionResult Edit(int id)
        {
            var person = _roleRepo.Read(id);

            if (person == null)
            {
                return RedirectToAction("Index", "Roles");
            }
            return View(person);
        }

        /// <summary>
        /// The Edit
        /// </summary>
        /// <param name="role">The role<see cref="Role"/></param>
        /// <returns>The <see cref="IActionResult"/></returns>
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

        /// <summary>
        /// Sets up the display for the details about a role.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>A View of the role object.</returns>
        public IActionResult Details(int id)
        {
            var role = _roleRepo.Read(id);

            return View(role);
        }
    }
}
