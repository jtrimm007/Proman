using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Proman.Models.DBEntities;

namespace Proman.Services
{
    public class ProjectRoleRepo : IProjectRole
    {
        private ProjectManDbContext _db;

        public ProjectRoleRepo(ProjectManDbContext db)
        {
            _db = db;
        }

        public void Create(ProjectRole projectRole)
        {
            _db.ProjectRole.Add(projectRole);
            _db.SaveChanges();
        }

        public void Delete(int id)
        {
            var projectRoleToDelete = Read(id);

            if(projectRoleToDelete != null)
            {
                _db.ProjectRole.Remove(projectRoleToDelete);
                _db.SaveChanges();
            }
        }

        public List<int> SelectPeopleOnProject(int id)
        {
            return _db.ProjectRole.Where(x => x.ProjectId == id).Select(x => x.PersonId).ToList();
        }
        public List<int> SelectProjectOnPeople(int id)
        {
            return _db.ProjectRole.Where(x => x.PersonId == id).Select(x => x.ProjectId).ToList();
        }

        public List<int> SelectRoleOnProjectByPersonId(int projectId, int personId)
        {
            return _db.ProjectRole.Where(x => x.ProjectId == projectId && x.PersonId == personId).Select(x => x.RoleId).ToList();

        }

        public decimal SumOfHourlyRateOnProjectById(int personId, int projectId, int roleId)
        {
            return _db.ProjectRole.Where(x => x.PersonId == personId
            && x.ProjectId == projectId && x.RoleId == roleId).Select(x => x.HourlyRate).Sum();
        }

        public decimal HourlyRate(int personId, int projectId, int roleId)
        {
            return _db.ProjectRole.FirstOrDefault(x => x.PersonId == personId
            && x.ProjectId == projectId && x.RoleId == roleId).HourlyRate;
        }
        public ProjectRole Read(int id)
        {
            return _db.ProjectRole.FirstOrDefault(p => p.Id == id);
        }

        public ICollection<ProjectRole> ReadAll()
        {
            return _db.ProjectRole.ToList();
        }

        public void Update(ProjectRole projectRole)
        {
            var projectRoleToUpdate = Read(projectRole.Id);

            if (projectRoleToUpdate != null)
            {
                projectRoleToUpdate.PersonId = projectRole.PersonId;
                projectRoleToUpdate.RoleId = projectRole.RoleId;
                projectRoleToUpdate.ProjectId = projectRole.ProjectId;
                projectRoleToUpdate.HourlyRate = projectRole.HourlyRate;


                _db.ProjectRole.Update(projectRoleToUpdate);
                _db.SaveChanges();
            }
        }
    }
}
