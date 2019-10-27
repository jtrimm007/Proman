namespace Proman.Models.DBEntities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Defines the <see cref="Project" />
    /// </summary>
    public class Project
    {
        /// <summary>
        /// Gets or sets the Id
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the Name
        /// </summary>
        [Required, MaxLength(30)]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the StartDate
        /// </summary>
        [Required, DataType(DataType.DateTime)]
        public DateTime StartDate { get; set; }

        /// <summary>
        /// Gets or sets the DueDate
        /// </summary>
        [Required, DataType(DataType.DateTime)]
        public DateTime DueDate { get; set; }

        /// <summary>
        /// Gets or sets the PeopleAssignedToProject
        /// </summary>
        public ICollection<Person> PeopleAssignedToProject { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Project"/> class.
        /// </summary>
        public Project()
        {
            PeopleAssignedToProject = new List<Person>();
        }
    }
}
