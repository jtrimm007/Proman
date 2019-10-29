namespace Proman.Services
{
    using Proman.Models.DBEntities;
    using System.Collections.Generic;

    /// <summary>
    /// Defines the <see cref="IProjectRole" />
    /// </summary>
    public interface IProjectRole
    {
        /// <summary>
        /// The Read
        /// </summary>
        /// <param name="id">The id<see cref="int"/></param>
        /// <returns>The <see cref="ProjectRole"/></returns>
        ProjectRole Read(int id);

        /// <summary>
        /// The ReadAll
        /// </summary>
        /// <returns>The <see cref="ICollection{ProjectRole}"/></returns>
        ICollection<ProjectRole> ReadAll();

        /// <summary>
        /// The Delete
        /// </summary>
        /// <param name="id">The id<see cref="int"/></param>
        void Delete(int id);

        /// <summary>
        /// The Update
        /// </summary>
        /// <param name="projectRole">The projectRole<see cref="ProjectRole"/></param>
        void Update(ProjectRole projectRole);

        /// <summary>
        /// The Create
        /// </summary>
        /// <param name="projectRole">The projectRole<see cref="ProjectRole"/></param>
        void Create(ProjectRole projectRole);

        /// <summary>
        /// The SelectRoleOnProjectByPersonId
        /// </summary>
        /// <param name="projectId">The projectId<see cref="int"/></param>
        /// <param name="personId">The personId<see cref="int"/></param>
        /// <returns>The <see cref="List{int}"/></returns>
        List<int> SelectRoleOnProjectByPersonId(int projectId, int personId);

        /// <summary>
        /// The SelectPeopleOnProject
        /// </summary>
        /// <param name="id">The id<see cref="int"/></param>
        /// <returns>The <see cref="List{int}"/></returns>
        List<int> SelectPeopleOnProject(int id);

        /// <summary>
        /// The SumOfHourlyRateOnProjectById
        /// </summary>
        /// <param name="personId">The personId<see cref="int"/></param>
        /// <param name="projectId">The projectId<see cref="int"/></param>
        /// <param name="roleId">The roleId<see cref="int"/></param>
        /// <returns>The <see cref="decimal"/></returns>
        decimal SumOfHourlyRateOnProjectById(int personId, int projectId, int roleId);

        /// <summary>
        /// The HourlyRate
        /// </summary>
        /// <param name="personId">The personId<see cref="int"/></param>
        /// <param name="projectId">The projectId<see cref="int"/></param>
        /// <param name="roleId">The roleId<see cref="int"/></param>
        /// <returns>The <see cref="decimal"/></returns>
        decimal HourlyRate(int personId, int projectId, int roleId);

        /// <summary>
        /// The SelectProjectOnPeople
        /// </summary>
        /// <param name="id">The id<see cref="int"/></param>
        /// <returns>The <see cref="List{int}"/></returns>
        List<int> SelectProjectOnPeople(int id);


        List<int> SelectProjectsAssignedToPeople(int id);
    }
}
