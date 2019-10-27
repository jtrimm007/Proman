namespace Proman.Models.ViewModels
{
    using Proman.Models.DBEntities;
    using System.Collections.Generic;

    /// <summary>
    /// Defines the <see cref="AddPersonToProjectVM" />
    /// </summary>
    public class AddPersonToProjectVM
    {
        /// <summary>
        /// Gets or sets the ProjectId
        /// </summary>
        public int ProjectId { get; set; }

        /// <summary>
        /// Gets or sets the ProjectName
        /// </summary>
        public string ProjectName { get; set; }

        /// <summary>
        /// Gets or sets the PeopleAvailable
        /// </summary>
        public List<Person> PeopleAvailable { get; set; }

        /// <summary>
        /// Gets or sets the PeopleNotAvailable
        /// </summary>
        public List<Person> PeopleNotAvailable { get; set; }
    }
}
