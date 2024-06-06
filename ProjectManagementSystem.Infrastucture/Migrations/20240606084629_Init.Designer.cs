﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using ProjectManagementSystem.Infrastucture.Data;

#nullable disable

namespace ProjectManagementSystem.Infrastucture.Migrations
{
    [DbContext(typeof(ProjectManagementSystemDbContext))]
    [Migration("20240606084629_Init")]
    partial class Init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("ProjectManagementSystem.Domain.Disciplines.Discipline", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<bool>("Deleted")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Discipline");
                });

            modelBuilder.Entity("ProjectManagementSystem.Domain.Groups.Group", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<bool>("Deleted")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Group");
                });

            modelBuilder.Entity("ProjectManagementSystem.Domain.ProjectStageAnswers.ProjectStageAnswer", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<bool>("Deleted")
                        .HasColumnType("boolean");

                    b.Property<string[]>("Files")
                        .IsRequired()
                        .HasColumnType("text[]");

                    b.Property<string>("Remark")
                        .HasColumnType("text");

                    b.Property<bool>("Returned")
                        .HasColumnType("boolean");

                    b.Property<Guid>("StudentId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("StudentId");

                    b.ToTable("ProjectStageAnswer");
                });

            modelBuilder.Entity("ProjectManagementSystem.Domain.ProjectStageMarks.ProjectStageMark", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<bool>("Deleted")
                        .HasColumnType("boolean");

                    b.Property<int>("Mark")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("ProjectStageMark");
                });

            modelBuilder.Entity("ProjectManagementSystem.Domain.ProjectStages.PinnedFile", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ProjectName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid?>("ProjectStageId")
                        .HasColumnType("uuid");

                    b.Property<string>("ProjectStageName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("ProjectStageId");

                    b.ToTable("PinnedFile");
                });

            modelBuilder.Entity("ProjectManagementSystem.Domain.ProjectStages.ProjectStage", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("Deadline")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("Deleted")
                        .HasColumnType("boolean");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid?>("MarkId")
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("ProjectId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("StudentId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("MarkId");

                    b.HasIndex("ProjectId");

                    b.HasIndex("StudentId");

                    b.ToTable("ProjectStage");
                });

            modelBuilder.Entity("ProjectManagementSystem.Domain.Projects.Project", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<bool>("Completed")
                        .HasColumnType("boolean");

                    b.Property<bool>("Deleted")
                        .HasColumnType("boolean");

                    b.Property<Guid>("DisciplineId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("GroupId")
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("SubjectArea")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Type")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("DisciplineId");

                    b.HasIndex("GroupId");

                    b.ToTable("Project");
                });

            modelBuilder.Entity("ProjectManagementSystem.Domain.StudentProjectStages.StudentProjectStage", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<bool>("Deleted")
                        .HasColumnType("boolean");

                    b.Property<Guid>("StageId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("StudentId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("StageId");

                    b.HasIndex("StudentId");

                    b.ToTable("StudentProjectStage");
                });

            modelBuilder.Entity("ProjectManagementSystem.Domain.Students.Student", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<bool>("Deleted")
                        .HasColumnType("boolean");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("Graduated")
                        .HasColumnType("boolean");

                    b.Property<Guid>("GroupId")
                        .HasColumnType("uuid");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("MiddleName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("GroupId");

                    b.ToTable("Student");
                });

            modelBuilder.Entity("ProjectManagementSystem.Domain.ProjectStageAnswers.ProjectStageAnswer", b =>
                {
                    b.HasOne("ProjectManagementSystem.Domain.Students.Student", "Student")
                        .WithMany()
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Student");
                });

            modelBuilder.Entity("ProjectManagementSystem.Domain.ProjectStages.PinnedFile", b =>
                {
                    b.HasOne("ProjectManagementSystem.Domain.ProjectStages.ProjectStage", null)
                        .WithMany("PinnedFiles")
                        .HasForeignKey("ProjectStageId");
                });

            modelBuilder.Entity("ProjectManagementSystem.Domain.ProjectStages.ProjectStage", b =>
                {
                    b.HasOne("ProjectManagementSystem.Domain.ProjectStageMarks.ProjectStageMark", "Mark")
                        .WithMany()
                        .HasForeignKey("MarkId");

                    b.HasOne("ProjectManagementSystem.Domain.Projects.Project", "Project")
                        .WithMany("Stages")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProjectManagementSystem.Domain.Students.Student", "Student")
                        .WithMany()
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Mark");

                    b.Navigation("Project");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("ProjectManagementSystem.Domain.Projects.Project", b =>
                {
                    b.HasOne("ProjectManagementSystem.Domain.Disciplines.Discipline", "Discipline")
                        .WithMany()
                        .HasForeignKey("DisciplineId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProjectManagementSystem.Domain.Groups.Group", "Group")
                        .WithMany()
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Discipline");

                    b.Navigation("Group");
                });

            modelBuilder.Entity("ProjectManagementSystem.Domain.StudentProjectStages.StudentProjectStage", b =>
                {
                    b.HasOne("ProjectManagementSystem.Domain.ProjectStages.ProjectStage", "Stage")
                        .WithMany()
                        .HasForeignKey("StageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProjectManagementSystem.Domain.Students.Student", "Student")
                        .WithMany()
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Stage");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("ProjectManagementSystem.Domain.Students.Student", b =>
                {
                    b.HasOne("ProjectManagementSystem.Domain.Groups.Group", "Group")
                        .WithMany()
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Group");
                });

            modelBuilder.Entity("ProjectManagementSystem.Domain.ProjectStages.ProjectStage", b =>
                {
                    b.Navigation("PinnedFiles");
                });

            modelBuilder.Entity("ProjectManagementSystem.Domain.Projects.Project", b =>
                {
                    b.Navigation("Stages");
                });
#pragma warning restore 612, 618
        }
    }
}
