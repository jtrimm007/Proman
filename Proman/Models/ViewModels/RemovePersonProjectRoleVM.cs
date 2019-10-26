using Proman.Models.DBEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proman.Models.ViewModels
{
    public class RemovePersonProjectRoleVM
    {
        public string UserName { get; set; }
        public int UserId { get; set; }
        public string ProjectName { get; set; }
        public int ProjectId { get; set; }
        public List<ProjectRole> ProjectRoleId { get; set; }
        public List<Role> UserRoles { get; set; }

    }
}
