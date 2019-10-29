namespace Proman.Services
{
    using Proman.Models.DBEntities;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Defines the <see cref="ProjectRoleRepo" />
    /// </summary>
    public class ProjectRoleRepo : IProjectRole
    {
        /// <summary>
        /// Defines the _db
        /// </summary>
        private ProjectManDbContext _db;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProjectRoleRepo"/> class.
        /// </summary>
        /// <param name="db">The db<see cref="ProjectManDbContext"/></param>
        public ProjectRoleRepo(ProjectManDbContext db)
        {
            _db = db;
        }

        /// <summary>
        /// The Create
        /// </summary>
        /// <param name="projectRole">The projectRole<see cref="ProjectRole"/></param>
        public void Create(ProjectRole projectRole)
        {
            _db.ProjectRole.Add(projectRole);
            _db.SaveChanges();
        }

        /// <summary>
        /// The Delete
        /// </summary>
        /// <param name="id">The id<see cref="int"/></param>
        public void Delete(int id)
        {
            var projectRoleToDelete = Read(id);

            if (projectRoleToDelete != null)
            {
                _db.ProjectRole.Remove(projectRoleToDelete);
                _db.SaveChanges();
            }
        }

        /// <summary>
        /// The SelectPeopleOnProject
        /// </summary>
        /// <param name="id">The id<see cref="int"/></param>
        /// <returns>The <see cref="List{int}"/></returns>
        public List<int> SelectPeopleOnProject(int id)
        {
            return _db.ProjectRole.Where(x => x.ProjectId == id).Select(x => x.PersonId).ToList();
        }

        public List<int> SelectProjectsAssignedToPeople(int id)
        {
            return _db.ProjectRole.Where(x => x.PersonId == id).Select(x => x.ProjectId).ToList();
        }

        /// <summary>
        /// The SelectProjectOnPeople
        /// </summary>
        /// <param name="id">The id<see cref="int"/></param>
        /// <returns>The <see cref="List{int}"/></returns>
        public List<int> SelectProjectOnPeople(int id)
        {
            return _db.ProjectRole.Where(x => x.PersonId == id).Select(x => x.ProjectId).ToList();
        }

        /// <summary>
        /// The SelectRoleOnProjectByPersonId
        /// </summary>
        /// <param name="projectId">The projectId<see cref="int"/></param>
        /// <param name="personId">The personId<see cref="int"/></param>
        /// <returns>The <see cref="List{int}"/></returns>
        public List<int> SelectRoleOnProjectByPersonId(int projectId, int personId)
        {
            return _db.ProjectRole.Where(x => x.ProjectId == projectId && x.PersonId == personId).Select(x => x.RoleId).ToList();
        }

        /// <summary>
        /// The SumOfHourlyRateOnProjectById
        /// </summary>
        /// <param name="personId">The personId<see cref="int"/></param>
        /// <param name="projectId">The projectId<see cref="int"/></param>
        /// <param name="roleId">The roleId<see cref="int"/></param>
        /// <returns>The <see cref="decimal"/></returns>
        public decimal SumOfHourlyRateOnProjectById(int personId, int projectId, int roleId)
        {
            return _db.ProjectRole.Where(x => x.PersonId == personId
            && x.ProjectId == projectId && x.RoleId == roleId).Select(x => x.HourlyRate).Sum();
        }

        /// <summary>
        /// The HourlyRate
        /// </summary>
        /// <param name="personId">The personId<see cref="int"/></param>
        /// <param name="projectId">The projectId<see cref="int"/></param>
        /// <param name="roleId">The roleId<see cref="int"/></param>
        /// <returns>The <see cref="decimal"/></returns>
        public decimal HourlyRate(int personId, int projectId, int roleId)
        {
            return _db.ProjectRole.FirstOrDefault(x => x.PersonId == personId
            && x.ProjectId == projectId && x.RoleId == roleId).HourlyRate;
        }

        /// <summary>
        /// The Read
        /// </summary>
        /// <param name="id">The id<see cref="int"/></param>
        /// <returns>The <see cref="ProjectRole"/></returns>
        public ProjectRole Read(int id)
        {
            return _db.ProjectRole.FirstOrDefault(p => p.Id == id);
        }

        /// <summary>
        /// The ReadAll
        /// </summary>
        /// <returns>The <see cref="ICollection{ProjectRole}"/></returns>
        public ICollection<ProjectRole> ReadAll()
        {
            return _db.ProjectRole.ToList();
        }

        /// <summary>
        /// The Update
        /// </summary>
        /// <param name="projectRole">The projectRole<see cref="ProjectRole"/></param>
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
