﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Proman.Services;

namespace Proman.Migrations
{
    [DbContext(typeof(ProjectManDbContext))]
    partial class ProjectManDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.3-servicing-35854")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Proman.Models.DBEntities.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.Property<string>("MiddleName")
                        .HasMaxLength(30);

                    b.Property<int?>("ProjectId");

                    b.HasKey("Id");

                    b.HasIndex("ProjectId");

                    b.ToTable("Person");
                });

            modelBuilder.Entity("Proman.Models.DBEntities.Project", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DueDate");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.Property<DateTime>("StartDate");

                    b.HasKey("Id");

                    b.ToTable("Project");
                });

            modelBuilder.Entity("Proman.Models.DBEntities.ProjectRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("HourlyRate");

                    b.Property<int>("PersonId");

                    b.Property<int>("ProjectId");

                    b.Property<int>("RoleId");

                    b.HasKey("Id");

                    b.HasIndex("PersonId");

                    b.ToTable("ProjectRole");
                });

            modelBuilder.Entity("Proman.Models.DBEntities.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasMaxLength(450);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.HasKey("Id");

                    b.ToTable("Role");
                });

            modelBuilder.Entity("Proman.Models.DBEntities.Person", b =>
                {
                    b.HasOne("Proman.Models.DBEntities.Project")
                        .WithMany("PeopleAssignedToProject")
                        .HasForeignKey("ProjectId");
                });

            modelBuilder.Entity("Proman.Models.DBEntities.ProjectRole", b =>
                {
                    b.HasOne("Proman.Models.DBEntities.Person")
                        .WithMany("ProjectRoles")
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
