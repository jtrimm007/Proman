using Microsoft.EntityFrameworkCore;
using Proman.Models.DBEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proman.Services
{
    public class ProjectManDbContext : DbContext
    {
        public ProjectManDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Person> Person { get; set; }
        public DbSet<ProjectRole> ProjectRole { get; set; }
        public DbSet<Project> Project { get; set; }
        public DbSet<Role> Role { get; set; }

    }
}
