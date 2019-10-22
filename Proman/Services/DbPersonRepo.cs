using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Proman.Models.DBEntities;

namespace Proman.Services
{
    public class DbPersonRepo : IPerson
    {
        private ProjectManDbContext _db;

        public DbPersonRepo(ProjectManDbContext db)
        {
            _db = db;
        }

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

        public void Delete(int id)
        {

            var personExist = Read(id);

            if (personExist != null)
            {
                _db.Person.Remove(personExist);
                _db.SaveChanges();
            }
        }

        public Person Read(int id)
        {
            return _db.Person.FirstOrDefault(p => p.Id == id);
        }

        public ICollection<Person> ReadAll()
        {
            return _db.Person.ToList();
        }

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
