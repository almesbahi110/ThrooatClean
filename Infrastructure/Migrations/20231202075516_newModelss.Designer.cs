﻿// <auto-generated />
using System;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastructure.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20231202075516_newModelss")]
    partial class newModelss
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Domain.Entities.Employee", b =>
                {
                    b.Property<int>("EmployeeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EmployeeId"));

                    b.Property<DateTime?>("Birthdate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Department")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EmployeeName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("EmployeeState")
                        .HasColumnType("int");

                    b.Property<int?>("Gender")
                        .HasColumnType("int");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EmployeeId");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("Domain.Entities.Process", b =>
                {
                    b.Property<int?>("ProcessId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("ProcessId"));

                    b.Property<string>("Instructions")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProcessName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ProcessState")
                        .HasColumnType("int");

                    b.HasKey("ProcessId");

                    b.ToTable("Processs");
                });

            modelBuilder.Entity("Domain.Entities.ProcessRequest", b =>
                {
                    b.Property<int?>("ProcessRequestId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("ProcessRequestId"));

                    b.Property<DateTime?>("DateBegin")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateEnd")
                        .HasColumnType("datetime2");

                    b.Property<int?>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<string>("Note")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ProcessRequestState")
                        .HasColumnType("int");

                    b.Property<int?>("ProcessStagesId")
                        .HasColumnType("int");

                    b.Property<string>("RequestDescraption")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ProcessRequestId");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("ProcessStagesId");

                    b.ToTable("ProcessRequests");
                });

            modelBuilder.Entity("Domain.Entities.ProcessStages", b =>
                {
                    b.Property<int?>("ProcessStagesId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("ProcessStagesId"));

                    b.Property<int?>("Next")
                        .HasColumnType("int");

                    b.Property<int?>("Order")
                        .HasColumnType("int");

                    b.Property<int?>("ProcessId")
                        .HasColumnType("int");

                    b.Property<int?>("StageId")
                        .HasColumnType("int");

                    b.HasKey("ProcessStagesId");

                    b.HasIndex("ProcessId");

                    b.HasIndex("StageId");

                    b.ToTable("ProcessStagess");
                });

            modelBuilder.Entity("Domain.Entities.Stage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.ToTable("Stages");
                });

            modelBuilder.Entity("Domain.Entities.ProcessRequest", b =>
                {
                    b.HasOne("Domain.Entities.Employee", "Employee")
                        .WithMany()
                        .HasForeignKey("EmployeeId");

                    b.HasOne("Domain.Entities.ProcessStages", "ProcessStages")
                        .WithMany()
                        .HasForeignKey("ProcessStagesId");

                    b.Navigation("Employee");

                    b.Navigation("ProcessStages");
                });

            modelBuilder.Entity("Domain.Entities.ProcessStages", b =>
                {
                    b.HasOne("Domain.Entities.Process", "Process")
                        .WithMany()
                        .HasForeignKey("ProcessId");

                    b.HasOne("Domain.Entities.Stage", "Stage")
                        .WithMany()
                        .HasForeignKey("StageId");

                    b.Navigation("Process");

                    b.Navigation("Stage");
                });

            modelBuilder.Entity("Domain.Entities.Stage", b =>
                {
                    b.HasOne("Domain.Entities.Employee", "Employee")
                        .WithMany()
                        .HasForeignKey("EmployeeId");

                    b.Navigation("Employee");
                });
#pragma warning restore 612, 618
        }
    }
}