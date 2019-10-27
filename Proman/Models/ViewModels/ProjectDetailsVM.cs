namespace Proman.Models.ViewModels
{
    using Proman.Models.DBEntities;
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Defines the <see cref="ProjectDetailsVM" />
    /// </summary>
    public class ProjectDetailsVM
    {
        /// <summary>
        /// Gets or sets the ProjectId
        /// </summary>
        public int ProjectId { get; set; }

        /// <summary>
        /// Gets or sets the Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the StartDate
        /// </summary>
        public DateTime StartDate { get; set; }

        /// <summary>
        /// Gets or sets the DueDate
        /// </summary>
        public DateTime DueDate { get; set; }

        /// <summary>
        /// Gets or sets the DaysLeft
        /// </summary>
        public double DaysLeft { get; set; }

        /// <summary>
        /// Gets or sets the PeopleAssignedToProject
        /// </summary>
        public List<Person> PeopleAssignedToProject { get; set; }

        /// <summary>
        /// Gets or sets the NumberOfPeopleAssigned
        /// </summary>
        public int NumberOfPeopleAssigned { get; set; }

        /// <summary>
        /// Gets or sets the ProjectRoles
        /// </summary>
        public List<ProjectRole> ProjectRoles { get; set; }

        /// <summary>
        /// Gets or sets the PersonRoles
        /// </summary>
        public Dictionary<Person, List<Role>> PersonRoles { get; set; }
    }
}
