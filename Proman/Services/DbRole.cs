using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Proman.Models.DBEntities;

namespace Proman.Services
{
    public class DbRole : IRole
    {
        private ProjectManDbContext _db;

        public DbRole(ProjectManDbContext db)
        {
            _db = db;
        }

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

        public void Delete(int id)
        {
            var roleToDelete = Read(id);

            if(roleToDelete != null || roleToDelete.Id != 1)
            {
                _db.Role.Remove(roleToDelete);
                _db.SaveChanges();
            }

           
        }

        public Role Read(int id)
        {
            return _db.Role.FirstOrDefault(p => p.Id == id);
        }

        public ICollection<Role> ReadAll()
        {
            return _db.Role.ToList();
        }

        public void Update(Role role)
        {
            var roleToUpdate = Read(role.Id);

            if(roleToUpdate != null)
            {
                roleToUpdate.Name = role.Name;
                roleToUpdate.Description = role.Description;

                _db.Update(roleToUpdate);
                _db.SaveChanges();
            }
        }
    }
}
