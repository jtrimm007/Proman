namespace Proman.Models.ViewModels
{
    using Proman.Models.DBEntities;
    using System.Collections.Generic;

    /// <summary>
    /// Defines the <see cref="RemovePersonProjectRoleVM" />
    /// </summary>
    public class RemovePersonProjectRoleVM
    {
        /// <summary>
        /// Gets or sets the UserName
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// Gets or sets the UserId
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// Gets or sets the ProjectName
        /// </summary>
        public string ProjectName { get; set; }

        /// <summary>
        /// Gets or sets the ProjectId
        /// </summary>
        public int ProjectId { get; set; }

        /// <summary>
        /// Gets or sets the ProjectRoleId
        /// </summary>
        public List<ProjectRole> ProjectRoleId { get; set; }

        /// <summary>
        /// Gets or sets the UserRoles
        /// </summary>
        public List<Role> UserRoles { get; set; }
    }
}
