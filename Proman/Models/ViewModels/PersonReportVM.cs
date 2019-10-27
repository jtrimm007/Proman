namespace Proman.Models.ViewModels
{
    using Proman.Models.DBEntities;
    using System.Collections.Generic;

    /// <summary>
    /// Defines the <see cref="PersonReportVM" />
    /// </summary>
    public class PersonReportVM
    {
        /// <summary>
        /// Gets or sets the Projects
        /// </summary>
        public List<Project> Projects { get; set; }

        /// <summary>
        /// Gets or sets the Person
        /// </summary>
        public List<Person> Person { get; set; }

        /// <summary>
        /// Gets or sets the Roles
        /// </summary>
        public List<Role> Roles { get; set; }

        /// <summary>
        /// Gets or sets the ProjectRoles
        /// </summary>
        public List<ProjectRole> ProjectRoles { get; set; }

        /// <summary>
        /// Gets or sets the HourlyTotal
        /// </summary>
        public Dictionary<Project, decimal> HourlyTotal { get; set; }

        /// <summary>
        /// Gets or sets the ListOfProjectsAndPeople
        /// </summary>
        public Dictionary<string, Dictionary<Project, Dictionary<Role, decimal>>> ListOfProjectsAndPeople { get; set; }
    }
}
