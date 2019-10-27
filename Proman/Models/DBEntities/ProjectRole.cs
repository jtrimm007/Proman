namespace Proman.Models.DBEntities
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// Defines the <see cref="ProjectRole" />
    /// </summary>
    public class ProjectRole
    {
        /// <summary>
        /// Gets or sets the Id
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the PersonId
        /// </summary>
        [ForeignKey("Person")]
        public int PersonId { get; set; }

        /// <summary>
        /// Gets or sets the ProjectId
        /// </summary>
        [ForeignKey("Project")]
        public int ProjectId { get; set; }

        /// <summary>
        /// Gets or sets the RoleId
        /// </summary>
        [ForeignKey("Role")]
        public int RoleId { get; set; }

        /// <summary>
        /// Gets or sets the HourlyRate
        /// </summary>
        [Required]
        public decimal HourlyRate { get; set; }
    }
}
