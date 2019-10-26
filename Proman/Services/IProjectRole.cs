using Proman.Models.DBEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proman.Services
{
    public interface IProjectRole
    {
        ProjectRole Read(int id);
        ICollection<ProjectRole> ReadAll();
        void Delete(int id);
        void Update(ProjectRole projectRole);
        void Create(ProjectRole projectRole);
        List<int> SelectRoleOnProjectByPersonId(int projectId, int personId);
        List<int> SelectPeopleOnProject(int id);
        decimal SumOfHourlyRateOnProjectById(int personId, int projectId, int roleId);
        decimal HourlyRate(int personId, int projectId, int roleId);
        List<int> SelectProjectOnPeople(int id);

    }
}
