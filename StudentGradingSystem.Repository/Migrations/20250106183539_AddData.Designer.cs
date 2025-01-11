﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StudentGradingSystem.Context;

#nullable disable

namespace StudentGradingSystem.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20250106183539_AddData")]
    partial class AddData
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("StudentGradingSystem.Models.Course", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Courses");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "C++"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Python"
                        });
                });

            modelBuilder.Entity("StudentGradingSystem.Models.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateOnly>("DateofBirth")
                        .HasColumnType("date");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Students");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DateofBirth = new DateOnly(2005, 5, 20),
                            Email = "Ahmed@gmail.com",
                            FirstName = "Ahmed",
                            LastName = "Mohamed",
                            Phone = "01234567891"
                        },
                        new
                        {
                            Id = 2,
                            DateofBirth = new DateOnly(2004, 10, 15),
                            Email = "AliMahmoud@gmail.com",
                            FirstName = "Ali",
                            LastName = "Mahmoud",
                            Phone = "01234567891"
                        });
                });

            modelBuilder.Entity("StudentGradingSystem.Models.StudentCourse", b =>
                {
                    b.Property<int>("StudentId")
                        .HasColumnType("int");

                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.Property<int>("Grade")
                        .HasColumnType("int");

                    b.HasKey("StudentId", "CourseId");

                    b.HasIndex("CourseId");

                    b.ToTable("StudentCourses");

                    b.HasData(
                        new
                        {
                            StudentId = 1,
                            CourseId = 2,
                            Grade = 90
                        },
                        new
                        {
                            StudentId = 2,
                            CourseId = 1,
                            Grade = 75
                        });
                });

            modelBuilder.Entity("StudentGradingSystem.Models.StudentCourse", b =>
                {
                    b.HasOne("StudentGradingSystem.Models.Course", "Course")
                        .WithMany()
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StudentGradingSystem.Models.Student", "Student")
                        .WithMany()
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("Student");
                });
#pragma warning restore 612, 618
        }
    }
}
