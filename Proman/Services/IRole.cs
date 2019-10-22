using Proman.Models.DBEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proman.Services
{
    public interface IRole
    {
        Role Read(int id);
        ICollection<Role> ReadAll();
        void Delete(int id);
        void Update(Role role);
        void Add(Role role);
    }
}
