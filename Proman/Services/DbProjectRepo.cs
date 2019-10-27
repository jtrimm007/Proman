namespace Proman.Services
{
    using Proman.Models.DBEntities;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Defines the <see cref="DbProjectRepo" />
    /// </summary>
    public class DbProjectRepo : IProject
    {
        /// <summary>
        /// Defines the _db
        /// </summary>
        private ProjectManDbContext _db;

        /// <summary>
        /// Initializes a new instance of the <see cref="DbProjectRepo"/> class.
        /// </summary>
        /// <param name="db">The db<see cref="ProjectManDbContext"/></param>
        public DbProjectRepo(ProjectManDbContext db)
        {
            _db = db;
        }

        /// <summary>
        /// The Add
        /// </summary>
        /// <param name="project">The project<see cref="Project"/></param>
        public void Add(Project project)
        {
            //var newProject = Read(project.Id);

            //if (newProject != null)
            //{
            _db.Project.Add(project);
            _db.SaveChanges();
        }

        /// <summary>
        /// The Delete
        /// </summary>
        /// <param name="id">The id<see cref="int"/></param>
        public void Delete(int id)
        {
            var toDelete = Read(id);

            if (toDelete != null)
            {
                _db.Project.Remove(toDelete);
                _db.SaveChanges();
            }
        }

        /// <summary>
        /// The Read
        /// </summary>
        /// <param name="id">The id<see cref="int"/></param>
        /// <returns>The <see cref="Project"/></returns>
        public Project Read(int id)
        {
            return _db.Project.FirstOrDefault(p => p.Id == id);
        }

        /// <summary>
        /// The ReadAll
        /// </summary>
        /// <returns>The <see cref="ICollection{Project}"/></returns>
        public ICollection<Project> ReadAll()
        {
            return _db.Project.ToList();
        }

        /// <summary>
        /// The Update
        /// </summary>
        /// <param name="project">The project<see cref="Project"/></param>
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
