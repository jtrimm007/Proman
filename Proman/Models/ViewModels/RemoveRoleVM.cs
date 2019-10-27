namespace Proman.Models.ViewModels
{
    using Proman.Models.DBEntities;
    using System.Collections.Generic;

    /// <summary>
    /// Defines the <see cref="RemoveRoleVM" />
    /// </summary>
    public class RemoveRoleVM
    {
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

        /// <summary>
        /// Gets or sets the ProjectRoles
        /// </summary>
        public List<ProjectRole> ProjectRoles { get; set; }

        /// <summary>
        /// Gets or sets the UserRoles
        /// </summary>
        public List<Role> UserRoles { get; set; }
    }
}
