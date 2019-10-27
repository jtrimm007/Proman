namespace Proman.Services
{
    using Proman.Models.DBEntities;
    using System.Collections.Generic;

    /// <summary>
    /// Defines the <see cref="IProject" />
    /// </summary>
    public interface IProject
    {
        /// <summary>
        /// The Read
        /// </summary>
        /// <param name="id">The id<see cref="int"/></param>
        /// <returns>The <see cref="Project"/></returns>
        Project Read(int id);

        /// <summary>
        /// The ReadAll
        /// </summary>
        /// <returns>The <see cref="ICollection{Project}"/></returns>
        ICollection<Project> ReadAll();

        /// <summary>
        /// The Delete
        /// </summary>
        /// <param name="id">The id<see cref="int"/></param>
        void Delete(int id);

        /// <summary>
        /// The Update
        /// </summary>
        /// <param name="project">The project<see cref="Project"/></param>
        void Update(Project project);

        /// <summary>
        /// The Add
        /// </summary>
        /// <param name="project">The project<see cref="Project"/></param>
        void Add(Project project);
    }
}
