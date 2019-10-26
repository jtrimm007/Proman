using Proman.Models.DBEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proman.Models.ViewModels
{
    public class RemoveRoleVM
    {
        public int PersonId { get; set; }
        public string PersonName { get; set; }
        public int ProjectId { get; set; }
        public string ProjectName { get; set; }
        public List<ProjectRole> ProjectRoles { get; set; }
        public List<Role> UserRoles { get; set; }
    }
}
