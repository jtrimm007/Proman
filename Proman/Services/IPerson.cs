using Proman.Models.DBEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proman.Services
{
    public interface IPerson
    {
        Person Read(int id);
        ICollection<Person> ReadAll();
        void Delete(int id);
        void Update(Person person);
        void Add(Person person);
    }
}
