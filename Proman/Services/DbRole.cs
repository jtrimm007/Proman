namespace Proman.Services
{
    using Proman.Models.DBEntities;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Defines the <see cref="DbRole" />
    /// </summary>
    public class DbRole : IRole
    {
        /// <summary>
        /// Defines the _db
        /// </summary>
        private ProjectManDbContext _db;

        /// <summary>
        /// Initializes a new instance of the <see cref="DbRole"/> class.
        /// </summary>
        /// <param name="db">The db<see cref="ProjectManDbContext"/></param>
        public DbRole(ProjectManDbContext db)
        {
            _db = db;
        }

        /// <summary>
        /// The Add
        /// </summary>
        /// <param name="role">The role<see cref="Role"/></param>
        public void Add(Role role)
        {
            var id = role.Id;
            var personExist = Read(id);

            if (personExist == null)
            {
                _db.Role.Add(role);
                _db.SaveChanges();
            }
        }

        /// <summary>
        /// The Delete
        /// </summary>
        /// <param name="id">The id<see cref="int"/></param>
        public void Delete(int id)
        {
            var roleToDelete = Read(id);

            if (roleToDelete != null || roleToDelete.Id != 1)
            {
                _db.Role.Remove(roleToDelete);
                _db.SaveChanges();
            }
        }

        /// <summary>
        /// The Read
        /// </summary>
        /// <param name="id">The id<see cref="int"/></param>
        /// <returns>The <see cref="Role"/></returns>
        public Role Read(int id)
        {
            return _db.Role.FirstOrDefault(p => p.Id == id);
        }

        /// <summary>
        /// The ReadAll
        /// </summary>
        /// <returns>The <see cref="ICollection{Role}"/></returns>
        public ICollection<Role> ReadAll()
        {
            return _db.Role.ToList();
        }

        /// <summary>
        /// The Update
        /// </summary>
        /// <param name="role">The role<see cref="Role"/></param>
        public void Update(Role role)
        {
            var roleToUpdate = Read(role.Id);

            if (roleToUpdate != null)
            {
                roleToUpdate.Name = role.Name;
                roleToUpdate.Description = role.Description;

                _db.Update(roleToUpdate);
                _db.SaveChanges();
            }
        }
    }
}
