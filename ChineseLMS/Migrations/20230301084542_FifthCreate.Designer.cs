﻿// <auto-generated />
using System;
using ChineseLMS.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ChineseLMS.Migrations
{
    [DbContext(typeof(SchoolContext))]
    [Migration("20230301084542_FifthCreate")]
    partial class FifthCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.14");

            modelBuilder.Entity("ChineseLMS.Models.Course", b =>
                {
                    b.Property<int>("CourseID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Credits")
                        .HasColumnType("INTEGER");

                    b.Property<int>("DepartmentID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ModuleID")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.HasKey("CourseID");

                    b.HasIndex("DepartmentID");

                    b.ToTable("Course", (string)null);
                });

            modelBuilder.Entity("ChineseLMS.Models.CourseMessage", b =>
                {
                    b.Property<int>("CourseMessageID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CourseID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("InstructorID")
                        .HasColumnType("INTEGER");

                    b.Property<string>("MessageContent")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("MessageCreateDate")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("MessageEditDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("MessageTitle")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("CourseMessageID");

                    b.HasIndex("CourseID");

                    b.HasIndex("InstructorID");

                    b.ToTable("CourseMessage", (string)null);
                });

            modelBuilder.Entity("ChineseLMS.Models.CourseTimeBlock", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CourseID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("TimeBlock")
                        .HasColumnType("INTEGER");

                    b.HasKey("ID");

                    b.HasIndex("CourseID");

                    b.ToTable("CourseTimeBlock", (string)null);
                });

            modelBuilder.Entity("ChineseLMS.Models.Department", b =>
                {
                    b.Property<int>("DepartmentID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("Budget")
                        .HasColumnType("money");

                    b.Property<Guid>("ConcurrencyToken")
                        .IsConcurrencyToken()
                        .HasColumnType("TEXT");

                    b.Property<int?>("InstructorID")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("TEXT");

                    b.HasKey("DepartmentID");

                    b.HasIndex("InstructorID");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("ChineseLMS.Models.Enrollment", b =>
                {
                    b.Property<int>("EnrollmentID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CourseID")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("Grade")
                        .HasColumnType("INTEGER");

                    b.Property<int>("StudentID")
                        .HasColumnType("INTEGER");

                    b.HasKey("EnrollmentID");

                    b.HasIndex("CourseID");

                    b.HasIndex("StudentID");

                    b.ToTable("Enrollments");
                });

            modelBuilder.Entity("ChineseLMS.Models.Instructor", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("FirstMidName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT")
                        .HasColumnName("FirstName");

                    b.Property<DateTime>("HireDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.ToTable("Instructor", (string)null);
                });

            modelBuilder.Entity("ChineseLMS.Models.Module", b =>
                {
                    b.Property<int>("ModuleID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CourseID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Year")
                        .HasColumnType("INTEGER");

                    b.HasKey("ModuleID");

                    b.HasIndex("CourseID");

                    b.ToTable("Module", (string)null);
                });

            modelBuilder.Entity("ChineseLMS.Models.OfficeAssignment", b =>
                {
                    b.Property<int>("InstructorID")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Location")
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.HasKey("InstructorID");

                    b.ToTable("OfficeAssignments");
                });

            modelBuilder.Entity("ChineseLMS.Models.ResourceFile", b =>
                {
                    b.Property<int>("ResourceFileID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("CourseID")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("FileSubmissionDate")
                        .HasColumnType("TEXT");

                    b.Property<int>("SchoolAssignmentID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("StudentID")
                        .HasColumnType("INTEGER");

                    b.HasKey("ResourceFileID");

                    b.HasIndex("CourseID");

                    b.HasIndex("SchoolAssignmentID");

                    b.HasIndex("StudentID");

                    b.ToTable("ResourceFile", (string)null);
                });

            modelBuilder.Entity("ChineseLMS.Models.SchoolAssignment", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("AllDay")
                        .HasColumnType("INTEGER");

                    b.Property<int>("CourseID")
                        .HasColumnType("INTEGER");

                    b.Property<string>("JSONString")
                        .HasColumnType("TEXT");

                    b.Property<string>("SchoolAssignmentDetails")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("TEXT")
                        .HasColumnName("Task Details");

                    b.Property<DateTime>("TaskCreateDate")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("TaskDueEndTime")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("TaskDueStartTime")
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.HasIndex("CourseID");

                    b.ToTable("SchoolAssignment", (string)null);
                });

            modelBuilder.Entity("ChineseLMS.Models.Student", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ClassOf")
                        .HasColumnType("INTEGER")
                        .HasColumnName("ClassOf");

                    b.Property<DateTime>("EnrollmentDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstMidName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT")
                        .HasColumnName("FirstName");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.ToTable("Student", (string)null);
                });

            modelBuilder.Entity("ChineseLMS.Models.TimeBlock", b =>
                {
                    b.Property<int>("TimeBlockID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.HasKey("TimeBlockID");

                    b.ToTable("TimeBlock", (string)null);
                });

            modelBuilder.Entity("ChineseLMS.Models.Todo", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("ByTeacher")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Checked")
                        .HasColumnType("INTEGER");

                    b.Property<int>("SchoolAssignmentID")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("TodoDueDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("TodoName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.HasIndex("SchoolAssignmentID");

                    b.ToTable("Todos");
                });

            modelBuilder.Entity("CourseInstructor", b =>
                {
                    b.Property<int>("CoursesCourseID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("InstructorsID")
                        .HasColumnType("INTEGER");

                    b.HasKey("CoursesCourseID", "InstructorsID");

                    b.HasIndex("InstructorsID");

                    b.ToTable("CourseInstructor");
                });

            modelBuilder.Entity("ChineseLMS.Models.Course", b =>
                {
                    b.HasOne("ChineseLMS.Models.Department", "Department")
                        .WithMany("Courses")
                        .HasForeignKey("DepartmentID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");
                });

            modelBuilder.Entity("ChineseLMS.Models.CourseMessage", b =>
                {
                    b.HasOne("ChineseLMS.Models.Course", "Course")
                        .WithMany("CourseMessages")
                        .HasForeignKey("CourseID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ChineseLMS.Models.Instructor", null)
                        .WithMany("CourseMessages")
                        .HasForeignKey("InstructorID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");
                });

            modelBuilder.Entity("ChineseLMS.Models.CourseTimeBlock", b =>
                {
                    b.HasOne("ChineseLMS.Models.Course", null)
                        .WithMany("CourseTimeBlocks")
                        .HasForeignKey("CourseID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ChineseLMS.Models.Department", b =>
                {
                    b.HasOne("ChineseLMS.Models.Instructor", "Administrator")
                        .WithMany()
                        .HasForeignKey("InstructorID");

                    b.Navigation("Administrator");
                });

            modelBuilder.Entity("ChineseLMS.Models.Enrollment", b =>
                {
                    b.HasOne("ChineseLMS.Models.Course", "Course")
                        .WithMany("Enrollments")
                        .HasForeignKey("CourseID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ChineseLMS.Models.Student", "Student")
                        .WithMany("Enrollments")
                        .HasForeignKey("StudentID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("ChineseLMS.Models.Module", b =>
                {
                    b.HasOne("ChineseLMS.Models.Course", null)
                        .WithMany("Modules")
                        .HasForeignKey("CourseID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ChineseLMS.Models.OfficeAssignment", b =>
                {
                    b.HasOne("ChineseLMS.Models.Instructor", "Instructor")
                        .WithOne("OfficeAssignment")
                        .HasForeignKey("ChineseLMS.Models.OfficeAssignment", "InstructorID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Instructor");
                });

            modelBuilder.Entity("ChineseLMS.Models.ResourceFile", b =>
                {
                    b.HasOne("ChineseLMS.Models.Course", null)
                        .WithMany("ResourceFiles")
                        .HasForeignKey("CourseID");

                    b.HasOne("ChineseLMS.Models.SchoolAssignment", null)
                        .WithMany("ResourceFiles")
                        .HasForeignKey("SchoolAssignmentID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ChineseLMS.Models.Student", null)
                        .WithMany("ResourceFiles")
                        .HasForeignKey("StudentID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ChineseLMS.Models.SchoolAssignment", b =>
                {
                    b.HasOne("ChineseLMS.Models.Course", null)
                        .WithMany("SchoolAssignments")
                        .HasForeignKey("CourseID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ChineseLMS.Models.Todo", b =>
                {
                    b.HasOne("ChineseLMS.Models.SchoolAssignment", "SchoolAssignment")
                        .WithMany("Todos")
                        .HasForeignKey("SchoolAssignmentID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SchoolAssignment");
                });

            modelBuilder.Entity("CourseInstructor", b =>
                {
                    b.HasOne("ChineseLMS.Models.Course", null)
                        .WithMany()
                        .HasForeignKey("CoursesCourseID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ChineseLMS.Models.Instructor", null)
                        .WithMany()
                        .HasForeignKey("InstructorsID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ChineseLMS.Models.Course", b =>
                {
                    b.Navigation("CourseMessages");

                    b.Navigation("CourseTimeBlocks");

                    b.Navigation("Enrollments");

                    b.Navigation("Modules");

                    b.Navigation("ResourceFiles");

                    b.Navigation("SchoolAssignments");
                });

            modelBuilder.Entity("ChineseLMS.Models.Department", b =>
                {
                    b.Navigation("Courses");
                });

            modelBuilder.Entity("ChineseLMS.Models.Instructor", b =>
                {
                    b.Navigation("CourseMessages");

                    b.Navigation("OfficeAssignment");
                });

            modelBuilder.Entity("ChineseLMS.Models.SchoolAssignment", b =>
                {
                    b.Navigation("ResourceFiles");

                    b.Navigation("Todos");
                });

            modelBuilder.Entity("ChineseLMS.Models.Student", b =>
                {
                    b.Navigation("Enrollments");

                    b.Navigation("ResourceFiles");
                });
#pragma warning restore 612, 618
        }
    }
}
