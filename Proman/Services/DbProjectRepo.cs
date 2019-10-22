using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Proman.Models.DBEntities;

namespace Proman.Services
{
    public class DbProjectRepo : IProject
    {
        private ProjectManDbContext _db;

        public DbProjectRepo(ProjectManDbContext db)
        {
            _db = db;
        }
        public void Add(Project project)
        {
            //var newProject = Read(project.Id);

            //if (newProject != null)
            //{
            _db.Project.Add(project);
            _db.SaveChanges();
            //}
        }

        public void Delete(int id)
        {
            var toDelete = Read(id);

            if (toDelete != null)
            {
                _db.Project.Remove(toDelete);
                _db.SaveChanges();
            }
        }

        public Project Read(int id)
        {
            return _db.Project.FirstOrDefault(p => p.Id == id);
        }

        public ICollection<Project> ReadAll()
        {
            return _db.Project.ToList();
        }

        public void Update(Project project)
        {
            var projectToUpdate = Read(project.Id);

            if (projectToUpdate != null)
            {
                projectToUpdate.DueDate = project.DueDate;
                projectToUpdate.Name = project.Name;
                projectToUpdate.StartDate = project.StartDate;

                _db.Project.Update(projectToUpdate);
                _db.SaveChanges();
            }
        }
    }
}
