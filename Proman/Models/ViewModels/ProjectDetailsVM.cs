using Proman.Models.DBEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proman.Models.ViewModels
{
    public class ProjectDetailsVM
    {
        public int ProjectId { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime DueDate { get; set; }
        public double DaysLeft { get; set; }
        public List<Person> PeopleAssignedToProject { get; set; }
        public int NumberOfPeopleAssigned { get; set; }
        public List<ProjectRole> ProjectRoles { get; set; }
        public Dictionary<Person, List<Role>> PersonRoles { get; set; }

    }
}
