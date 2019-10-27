namespace Proman.Services
{
    using Proman.Models.DBEntities;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Defines the <see cref="DbPersonRepo" />
    /// </summary>
    public class DbPersonRepo : IPerson
    {
        /// <summary>
        /// Defines the _db
        /// </summary>
        private ProjectManDbContext _db;

        /// <summary>
        /// Initializes a new instance of the <see cref="DbPersonRepo"/> class.
        /// </summary>
        /// <param name="db">The db<see cref="ProjectManDbContext"/></param>
        public DbPersonRepo(ProjectManDbContext db)
        {
            _db = db;
        }

        /// <summary>
        /// The Add
        /// </summary>
        /// <param name="person">The person<see cref="Person"/></param>
        public void Add(Person person)
        {
            var id = person.Id;
            var personExist = Read(id);

            if (personExist == null)
            {
                _db.Person.Add(person);
                _db.SaveChanges();
            }
        }

        /// <summary>
        /// The Delete
        /// </summary>
        /// <param name="id">The id<see cref="int"/></param>
        public void Delete(int id)
        {

            var personExist = Read(id);

            if (personExist != null)
            {
                _db.Person.Remove(personExist);
                _db.SaveChanges();
            }
        }

        /// <summary>
        /// The SelectAllPeopleById
        /// </summary>
        /// <param name="id">The id<see cref="int"/></param>
        /// <returns>The <see cref="List{string}"/></returns>
        public List<string> SelectAllPeopleById(int id)
        {
            return _db.Person.Where(x => x.Id == id).Select(x => new { x.FirstName, x.LastName }.ToString()).ToList();
        }

        /// <summary>
        /// The Read
        /// </summary>
        /// <param name="id">The id<see cref="int"/></param>
        /// <returns>The <see cref="Person"/></returns>
        public Person Read(int id)
        {
            return _db.Person.FirstOrDefault(p => p.Id == id);
        }

        /// <summary>
        /// The ReadAll
        /// </summary>
        /// <returns>The <see cref="ICollection{Person}"/></returns>
        public ICollection<Person> ReadAll()
        {
            return _db.Person.ToList();
        }

        /// <summary>
        /// The Update
        /// </summary>
        /// <param name="person">The person<see cref="Person"/></param>
        public void Update(Person person)
        {
            var personToUpdate = Read(person.Id);

            if (personToUpdate != null)
            {
                personToUpdate.FirstName = person.FirstName;
                personToUpdate.MiddleName = person.MiddleName;
                personToUpdate.LastName = person.LastName;
                personToUpdate.Email = person.Email;

                _db.Person.Update(personToUpdate);
                _db.SaveChanges();
            }
        }
    }
}
