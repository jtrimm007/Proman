using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Proman.Models.DBEntities
{
    public class ProjectRole
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Person")]
        public int PersonId { get; set; }
        [ForeignKey("Project")]
        public int ProjectId { get; set; }
        [ForeignKey("Role")]
        public int RoleId { get; set; }
        [Required]
        public decimal HourlyRate { get; set; }
        //public ICollection<Person> Persons { get; set; }
        //public ICollection<Project> Projects { get; set; }
        //public ICollection<Role> Roles { get; set; }
    }
}
