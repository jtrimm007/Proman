using Proman.Models.DBEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proman.Models.ViewModels
{
    public class AddPersonToProjectVM
    {

        public int ProjectId { get; set; }
        public string ProjectName { get; set; }
        public List<Person> PeopleAvailable { get; set; }
        public List<Person> PeopleNotAvailable { get; set; }

    }
}
