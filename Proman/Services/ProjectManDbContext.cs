namespace Proman.Services
{
    using Microsoft.EntityFrameworkCore;
    using Proman.Models.DBEntities;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Defines the <see cref="ProjectManDbContext" />
    /// </summary>
    public class ProjectManDbContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ProjectManDbContext"/> class.
        /// </summary>
        /// <param name="options">The options<see cref="DbContextOptions"/></param>
        public ProjectManDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Course>()
            //       .HasKey(c => new { c.Code, c.Number });
            modelBuilder.Entity<ProjectRole>()
                   .HasAlternateKey(scg => new { scg.Id });
        }

        /// <summary>
        /// Gets or sets the Person
        /// </summary>
        public DbSet<Person> Person { get; set; }

        /// <summary>
        /// Gets or sets the ProjectRole
        /// </summary>
        public DbSet<ProjectRole> ProjectRole { get; set; }

        /// <summary>
        /// Gets or sets the Project
        /// </summary>
        public DbSet<Project> Project { get; set; }

        /// <summary>
        /// Gets or sets the Role
        /// </summary>
        public DbSet<Role> Role { get; set; }

        /// <summary>
        /// The Seed
        /// </summary>
        public void Seed()
        {
            Database.EnsureCreated();

            // If there are any students then the database is already seeded.
            if (Person.Any()) return;

            var person = new List<Person>
               {
                  new Person { FirstName = "James", MiddleName = "L", LastName = "Smith", Email = "jsmith@pman.com" },
                  new Person { FirstName = "Maria", MiddleName = "F", LastName = "Garcia", Email = "mgarcia@pman.com" },
                  new Person { FirstName = "Chen", MiddleName = "G", LastName = "Li", Email = "cli@pman.com" },
                  new Person { FirstName = "Aban", MiddleName = "G", LastName = "Hakim", Email = "ahakim@pman.com" }
               };

            Person.AddRange(person);
            SaveChanges();

            var projects = new List<Project>
               {
                   new Project { Name = "New Wifi Setup", StartDate = new System.DateTime(2019, 04, 04, 12, 49, 29), DueDate = new System.DateTime(2022, 04, 04, 12, 49, 29) },
                   new Project { Name = "Help a new student", StartDate = new System.DateTime(2009, 12, 14, 12, 49, 29), DueDate = new System.DateTime(2022, 04, 04, 12, 49, 29) },
                   new Project { Name = "Build a new house", StartDate = new System.DateTime(1988, 04, 04, 12, 49, 29), DueDate = new System.DateTime(2042, 03, 01, 12, 49, 29) }
               };

            Project.AddRange(projects);
            SaveChanges();

            var roles = new List<Role>
               {
                   new Role { Name = "Member", Description = "Does member stuff" },
                   new Role { Name = "Admin", Description = "Does admin stuff" },
                   new Role { Name = "Grave Digger", Description = "Don't ask this guy for anything...." }
               };

            Role.AddRange(roles);
            SaveChanges();

            Project newWifi = Project
                .FirstOrDefault(c => c.Id == 1);
            Project helpStudent = Project
                .FirstOrDefault(c => c.Id == 2);
            Project buildHouse = Project
                .FirstOrDefault(c => c.Id == 3);

            //Course csci3110 = Courses
            //   .FirstOrDefault(c => c.Code == "CSCI" && c.Number == "3110");
            //Course csci1250 = Courses
            //   .FirstOrDefault(c => c.Code == "CSCI" && c.Number == "1250");
            //Course csci1260 = Courses
            //   .FirstOrDefault(c => c.Code == "CSCI" && c.Number == "1260");

            Person james = Person
                .FirstOrDefault(s => s.Id == 1);
            Person maria = Person
               .FirstOrDefault(s => s.Id == 2);
            Person li = Person
               .FirstOrDefault(s => s.Id == 3);
            Person hakim = Person
               .FirstOrDefault(s => s.Id == 4);

            //Student james = Students
            //   .FirstOrDefault(s => s.ENumber == "E00000001");
            //Student maria = Students
            //   .FirstOrDefault(s => s.ENumber == "E00000002");
            //Student li = Students
            //   .FirstOrDefault(s => s.ENumber == "E00000003");
            //Student hakim = Students
            //   .FirstOrDefault(s => s.ENumber == "E00000004");

            Role member = Role
                .FirstOrDefault(s => s.Id == 1);
            Role admin = Role
                .FirstOrDefault(s => s.Id == 2);
            Role graveDigger = Role
                .FirstOrDefault(s => s.Id == 3);

            james.ProjectRoles.Add(
                new ProjectRole
                {
                    Id = 1,
                    PersonId = james.Id,
                    ProjectId = newWifi.Id,
                    RoleId = graveDigger.Id,
                    HourlyRate = 8
                }
                );

            maria.ProjectRoles.Add(
                new ProjectRole
                {
                    Id = 2,
                    PersonId = maria.Id,
                    ProjectId = buildHouse.Id,
                    RoleId = member.Id,
                    HourlyRate = 7
                }
                );

            li.ProjectRoles.Add(
                new ProjectRole
                {
                    Id = 3,
                    PersonId = li.Id,
                    ProjectId = helpStudent.Id,
                    RoleId = admin.Id,
                    HourlyRate = 30
                }
                );

            hakim.ProjectRoles.Add(
                new ProjectRole
                {
                    Id = 4,
                    PersonId = hakim.Id,
                    ProjectId = helpStudent.Id,
                    RoleId = member.Id,
                    HourlyRate = 45
                }
                );
            james.ProjectRoles.Add(
                new ProjectRole
                {
                    Id = 5,
                    PersonId = james.Id,
                    ProjectId = helpStudent.Id,
                    RoleId = member.Id,
                    HourlyRate = 8
                }
                );

            maria.ProjectRoles.Add(
                new ProjectRole
                {
                    Id = 6,
                    PersonId = maria.Id,
                    ProjectId = newWifi.Id,
                    RoleId = admin.Id,
                    HourlyRate = 7
                }
                );

            li.ProjectRoles.Add(
                new ProjectRole
                {
                    Id = 7,
                    PersonId = li.Id,
                    ProjectId = helpStudent.Id,
                    RoleId = member.Id,
                    HourlyRate = 20
                }
                );

            hakim.ProjectRoles.Add(
                new ProjectRole
                {
                    Id = 8,
                    PersonId = hakim.Id,
                    ProjectId = buildHouse.Id,
                    RoleId = graveDigger.Id,
                    HourlyRate = 100
                }
                );

            //james.Grades.Add(
            //   new StudentCourseGrade
            //   {
            //       LetterGrade = "B+",
            //       Course = csci3110
            //   }
            //);
            //james.Grades.Add(
            //   new StudentCourseGrade
            //   {
            //       LetterGrade = "C",
            //       Course = csci1250
            //   }
            //);

            //maria.Grades.Add(
            //   new StudentCourseGrade
            //   {
            //       LetterGrade = "A",
            //       Course = csci3110
            //   }
            //);
            //maria.Grades.Add(
            //   new StudentCourseGrade
            //   {
            //       LetterGrade = "D",
            //       Course = csci1250
            //   }
            //);
            //maria.Grades.Add(
            //   new StudentCourseGrade
            //   {
            //       LetterGrade = "F",
            //       Course = csci1260
            //   }
            //);

            //li.Grades.Add(
            //   new StudentCourseGrade
            //   {
            //       LetterGrade = "A-",
            //       Course = csci1250
            //   }
            //);

            //hakim.Grades.Add(
            //   new StudentCourseGrade
            //   {
            //       LetterGrade = "C+",
            //       Course = csci3110
            //   }
            //);
            //hakim.Grades.Add(
            //   new StudentCourseGrade
            //   {
            //       LetterGrade = "A",
            //       Course = csci1250
            //   }
            //);
            //hakim.Grades.Add(
            //   new StudentCourseGrade
            //   {
            //       LetterGrade = "A",
            //       Course = csci1260
            //   }
            //);
            SaveChanges();
        }
    }
}
