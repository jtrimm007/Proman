namespace Proman.Models.DBEntities
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Defines the <see cref="Role" />
    /// </summary>
    public class Role
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
        /// Gets or sets the Description
        /// </summary>
        [MaxLength(450)]
        public string Description { get; set; }
    }
}
