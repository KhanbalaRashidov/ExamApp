﻿// <auto-generated />
using System;
using ExamApp.DAL.Concrete.EntityFramework.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ExamApp.DAL.Migrations
{
    [DbContext(typeof(ExamDbContext))]
    partial class ExamDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0-preview.5.22302.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ExamApp.Entities.Concrete.Exam", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("ExamDate")
                        .HasColumnType("date");

                    b.Property<string>("LessonCode")
                        .IsRequired()
                        .HasColumnType("char(3)");

                    b.Property<decimal>("Score")
                        .HasColumnType("numeric(1,0)");

                    b.Property<decimal>("StudentNumber")
                        .HasColumnType("numeric(5,0)");

                    b.HasKey("Id");

                    b.HasIndex("LessonCode");

                    b.HasIndex("StudentNumber");

                    b.ToTable("Exams");
                });

            modelBuilder.Entity("ExamApp.Entities.Concrete.Lesson", b =>
                {
                    b.Property<string>("LessonCode")
                        .HasColumnType("char(3)");

                    b.Property<decimal>("Class")
                        .HasColumnType("numeric(2,0)");

                    b.Property<string>("LessonName")
                        .IsRequired()
                        .HasColumnType("varchar(30)");

                    b.Property<string>("TeacherName")
                        .IsRequired()
                        .HasColumnType("varchar(20)");

                    b.Property<string>("TeacherSurname")
                        .IsRequired()
                        .HasColumnType("varchar(20)");

                    b.HasKey("LessonCode");

                    b.ToTable("Lessons");
                });

            modelBuilder.Entity("ExamApp.Entities.Concrete.Student", b =>
                {
                    b.Property<decimal>("StudentNumber")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("numeric(5,0)");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<decimal>("StudentNumber"), 1L, 1);

                    b.Property<decimal>("Class")
                        .HasColumnType("numeric(2,0)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(30)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("varchar(30)");

                    b.HasKey("StudentNumber");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("ExamApp.Entities.Concrete.Exam", b =>
                {
                    b.HasOne("ExamApp.Entities.Concrete.Lesson", "Lesson")
                        .WithMany("Exams")
                        .HasForeignKey("LessonCode")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ExamApp.Entities.Concrete.Student", "Student")
                        .WithMany("Exams")
                        .HasForeignKey("StudentNumber")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Lesson");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("ExamApp.Entities.Concrete.Lesson", b =>
                {
                    b.Navigation("Exams");
                });

            modelBuilder.Entity("ExamApp.Entities.Concrete.Student", b =>
                {
                    b.Navigation("Exams");
                });
#pragma warning restore 612, 618
        }
    }
}
