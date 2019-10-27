namespace Proman.Services
{
    using Microsoft.EntityFrameworkCore;
    using Proman.Models.DBEntities;

    /// <summary>
    /// Defines the <see cref="ProjectManDbContext" />
    /// </summary>
    public class ProjectManDbContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ProjectManDbContext"/> class.
        /// </summary>
        /// <param name="options">The options<see cref="DbContextOptions"/></param>
        public ProjectManDbContext(DbContextOptions options) : base(options)
        {
        }

        /// <summary>
        /// Gets or sets the Person
        /// </summary>
        public DbSet<Person> Person { get; set; }

        /// <summary>
        /// Gets or sets the ProjectRole
        /// </summary>
        public DbSet<ProjectRole> ProjectRole { get; set; }

        /// <summary>
        /// Gets or sets the Project
        /// </summary>
        public DbSet<Project> Project { get; set; }

        /// <summary>
        /// Gets or sets the Role
        /// </summary>
        public DbSet<Role> Role { get; set; }
    }
}
