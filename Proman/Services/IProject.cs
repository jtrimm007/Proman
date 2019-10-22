using Proman.Models.DBEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proman.Services
{
    public interface IProject
    {
        Project Read(int id);
        ICollection<Project> ReadAll();
        void Delete(int id);
        void Update(Project project);
        void Add(Project project);
    }
}
