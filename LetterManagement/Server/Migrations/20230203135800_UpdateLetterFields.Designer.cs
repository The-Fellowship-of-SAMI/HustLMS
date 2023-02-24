﻿// <auto-generated />
using System;
using LetterManagement.Server.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LetterManagement.Server.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20230203135800_UpdateLetterFields")]
    partial class UpdateLetterFields
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.1");

            modelBuilder.Entity("LetterManagement.Shared.Models.ConfirmationTemplate", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("LetterTemplateId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("LetterTemplateId");

                    b.ToTable("ConfirmationTemplate");

                    b.HasDiscriminator<string>("Discriminator").HasValue("ConfirmationTemplate");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("LetterManagement.Shared.Models.Department", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("ModifiedAt")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("ShortName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("LetterManagement.Shared.Models.Letter", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("FinishedDate")
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("ManagerId")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("ModifiedAt")
                        .HasColumnType("TEXT");

                    b.Property<string>("NoteToStudent")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("ReceivedDate")
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("StudentId")
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("TemplateId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ManagerId");

                    b.HasIndex("StudentId");

                    b.HasIndex("TemplateId");

                    b.ToTable("Letters");
                });

            modelBuilder.Entity("LetterManagement.Shared.Models.LetterAdditionalField", b =>
                {
                    b.Property<Guid>("LetterAdditionalFieldId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<bool?>("FieldValueBool")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("FieldValueDateTime")
                        .HasColumnType("TEXT");

                    b.Property<string>("FieldValueString")
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("LetterId")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("LetterTemplateAdditionalFieldId")
                        .HasColumnType("TEXT");

                    b.HasKey("LetterAdditionalFieldId");

                    b.HasIndex("LetterId");

                    b.ToTable("LetterAdditionalField");
                });

            modelBuilder.Entity("LetterManagement.Shared.Models.LetterTemplate", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("DepartmentId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("Footer")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("ModifiedAt")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("Receiver")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.ToTable("LetterTemplates");
                });

            modelBuilder.Entity("LetterManagement.Shared.Models.Manager", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("DepartmentId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.ToTable("Manager");
                });

            modelBuilder.Entity("LetterManagement.Shared.Models.Student", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("LastLogin")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("ModifiedAt")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("SchoolId")
                        .HasColumnType("TEXT");

                    b.Property<string>("SchoolYear")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("StudentId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("SchoolId");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("LetterManagement.Shared.Models.TemplateAdditionalField", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("AdditionalText")
                        .HasColumnType("TEXT");

                    b.Property<string>("FieldName")
                        .HasColumnType("TEXT");

                    b.Property<int?>("FieldType")
                        .HasColumnType("INTEGER");

                    b.Property<Guid?>("GroupFieldId")
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("LetterTemplateId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("LetterTemplateId");

                    b.ToTable("TemplateAdditionalField");
                });

            modelBuilder.Entity("LetterManagement.Shared.Models.Confirmation", b =>
                {
                    b.HasBaseType("LetterManagement.Shared.Models.ConfirmationTemplate");

                    b.Property<DateTime?>("ActionDate")
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("DepartmentNeedToConfirmId")
                        .HasColumnType("TEXT");

                    b.Property<bool?>("IsOk")
                        .HasColumnType("INTEGER");

                    b.Property<Guid?>("LetterId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Note")
                        .HasColumnType("TEXT");

                    b.HasIndex("DepartmentNeedToConfirmId");

                    b.HasIndex("LetterId");

                    b.HasDiscriminator().HasValue("Confirmation");
                });

            modelBuilder.Entity("LetterManagement.Shared.Models.ConfirmationTemplate", b =>
                {
                    b.HasOne("LetterManagement.Shared.Models.LetterTemplate", null)
                        .WithMany("ConfirmationsTemplate")
                        .HasForeignKey("LetterTemplateId");
                });

            modelBuilder.Entity("LetterManagement.Shared.Models.Letter", b =>
                {
                    b.HasOne("LetterManagement.Shared.Models.Manager", "Manager")
                        .WithMany()
                        .HasForeignKey("ManagerId");

                    b.HasOne("LetterManagement.Shared.Models.Student", "Student")
                        .WithMany()
                        .HasForeignKey("StudentId");

                    b.HasOne("LetterManagement.Shared.Models.LetterTemplate", "Template")
                        .WithMany()
                        .HasForeignKey("TemplateId");

                    b.Navigation("Manager");

                    b.Navigation("Student");

                    b.Navigation("Template");
                });

            modelBuilder.Entity("LetterManagement.Shared.Models.LetterAdditionalField", b =>
                {
                    b.HasOne("LetterManagement.Shared.Models.Letter", null)
                        .WithMany("LetterAdditionalFields")
                        .HasForeignKey("LetterId");
                });

            modelBuilder.Entity("LetterManagement.Shared.Models.LetterTemplate", b =>
                {
                    b.HasOne("LetterManagement.Shared.Models.Department", "Department")
                        .WithMany()
                        .HasForeignKey("DepartmentId");

                    b.Navigation("Department");
                });

            modelBuilder.Entity("LetterManagement.Shared.Models.Manager", b =>
                {
                    b.HasOne("LetterManagement.Shared.Models.Department", "Department")
                        .WithMany()
                        .HasForeignKey("DepartmentId");

                    b.Navigation("Department");
                });

            modelBuilder.Entity("LetterManagement.Shared.Models.Student", b =>
                {
                    b.HasOne("LetterManagement.Shared.Models.Department", "School")
                        .WithMany()
                        .HasForeignKey("SchoolId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("School");
                });

            modelBuilder.Entity("LetterManagement.Shared.Models.TemplateAdditionalField", b =>
                {
                    b.HasOne("LetterManagement.Shared.Models.LetterTemplate", null)
                        .WithMany("AdditionalFields")
                        .HasForeignKey("LetterTemplateId");
                });

            modelBuilder.Entity("LetterManagement.Shared.Models.Confirmation", b =>
                {
                    b.HasOne("LetterManagement.Shared.Models.Department", "DepartmentNeedToConfirm")
                        .WithMany()
                        .HasForeignKey("DepartmentNeedToConfirmId");

                    b.HasOne("LetterManagement.Shared.Models.Letter", null)
                        .WithMany("Confirmations")
                        .HasForeignKey("LetterId");

                    b.Navigation("DepartmentNeedToConfirm");
                });

            modelBuilder.Entity("LetterManagement.Shared.Models.Letter", b =>
                {
                    b.Navigation("Confirmations");

                    b.Navigation("LetterAdditionalFields");
                });

            modelBuilder.Entity("LetterManagement.Shared.Models.LetterTemplate", b =>
                {
                    b.Navigation("AdditionalFields");

                    b.Navigation("ConfirmationsTemplate");
                });
#pragma warning restore 612, 618
        }
    }
}
