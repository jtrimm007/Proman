namespace Proman.Models.ViewModels
{
    using Proman.Models.DBEntities;
    using System.Collections.Generic;

    /// <summary>
    /// Defines the <see cref="AssignRoleToPersonVM" />
    /// </summary>
    public class AssignRoleToPersonVM
    {
        /// <summary>
        /// Gets or sets the Roles
        /// </summary>
        public List<Role> Roles { get; set; }

        /// <summary>
        /// Gets or sets the HourlyRate
        /// </summary>
        public decimal HourlyRate { get; set; }

        /// <summary>
        /// Gets or sets the PersonId
        /// </summary>
        public int PersonId { get; set; }

        /// <summary>
        /// Gets or sets the PersonName
        /// </summary>
        public string PersonName { get; set; }

        /// <summary>
        /// Gets or sets the ProjectId
        /// </summary>
        public int ProjectId { get; set; }

        /// <summary>
        /// Gets or sets the ProjectName
        /// </summary>
        public string ProjectName { get; set; }
    }
}
