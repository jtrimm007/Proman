using Proman.Models.DBEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proman.Models.ViewModels
{
    public class PersonReportVM
    {
        public List<Project> Projects { get; set; }
        public List<Person> Person { get; set; }
        public List<Role> Roles { get; set; }
        public List<ProjectRole> ProjectRoles { get; set; }
        public Dictionary<Project, decimal> HourlyTotal { get; set; }
        public Dictionary<string, Dictionary<Project, Dictionary<Role, decimal>>> ListOfProjectsAndPeople { get; set; }
    }
}
