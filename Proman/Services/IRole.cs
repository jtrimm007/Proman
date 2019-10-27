namespace Proman.Services
{
    using Proman.Models.DBEntities;
    using System.Collections.Generic;

    /// <summary>
    /// Defines the <see cref="IRole" />
    /// </summary>
    public interface IRole
    {
        /// <summary>
        /// The Read
        /// </summary>
        /// <param name="id">The id<see cref="int"/></param>
        /// <returns>The <see cref="Role"/></returns>
        Role Read(int id);

        /// <summary>
        /// The ReadAll
        /// </summary>
        /// <returns>The <see cref="ICollection{Role}"/></returns>
        ICollection<Role> ReadAll();

        /// <summary>
        /// The Delete
        /// </summary>
        /// <param name="id">The id<see cref="int"/></param>
        void Delete(int id);

        /// <summary>
        /// The Update
        /// </summary>
        /// <param name="role">The role<see cref="Role"/></param>
        void Update(Role role);

        /// <summary>
        /// The Add
        /// </summary>
        /// <param name="role">The role<see cref="Role"/></param>
        void Add(Role role);
    }
}
