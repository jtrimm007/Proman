using Proman.Models.DBEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proman.Models.ViewModels
{
    public class AssignRoleToPersonVM
    {
        public List<Role> Roles { get; set; }
        public decimal HourlyRate { get; set; }
        public int PersonId { get; set; }
        public string PersonName { get; set; }
        public int ProjectId { get; set; }
        public string ProjectName { get; set; }

    }
}
