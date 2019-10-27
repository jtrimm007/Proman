namespace Proman.Models.DBEntities
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Defines the <see cref="Person" />
    /// </summary>
    public class Person
    {
        /// <summary>
        /// Gets or sets the Id
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the FirstName
        /// </summary>
        [Required, MaxLength(30)]
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the MiddleName
        /// </summary>
        [MaxLength(30)]
        public string MiddleName { get; set; }

        /// <summary>
        /// Gets or sets the LastName
        /// </summary>
        [Required, MaxLength(30)]
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets the Email
        /// </summary>
        [Required]
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the ProjectRoles
        /// </summary>
        public ICollection<ProjectRole> ProjectRoles { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Person"/> class.
        /// </summary>
        public Person()
        {
            ProjectRoles = new List<ProjectRole>();
        }
    }
}
