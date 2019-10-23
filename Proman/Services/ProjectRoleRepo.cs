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
            }
        }

        public ProjectRole Read(int id)
        {
            return _db.ProjectRole.Include(p => p.Id).FirstOrDefault(p => p.Id == id);
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
