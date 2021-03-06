﻿// <auto-generated />
using System;
using HealthCare.Data.DataContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace HealthCare.Data.Migrations
{
    [DbContext(typeof(HealthCareContext))]
    partial class HealthCareContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("HealthCare.Data.Models.Patient", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateOfBirth");

                    b.Property<string>("Email");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<string>("PhoneNumber");

                    b.HasKey("Id");

                    b.ToTable("Patients");
                });

            modelBuilder.Entity("HealthCare.Data.Models.PatientVisit", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Comment");

                    b.Property<long?>("PatientId");

                    b.Property<long?>("StatusId");

                    b.Property<DateTime>("VisitDate");

                    b.Property<long?>("VisitId");

                    b.HasKey("Id");

                    b.HasIndex("PatientId");

                    b.HasIndex("StatusId");

                    b.HasIndex("VisitId");

                    b.ToTable("PatientVisits");
                });

            modelBuilder.Entity("HealthCare.Data.Models.PatientVisitStatus", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("PatientVisitStatuses");
                });

            modelBuilder.Entity("HealthCare.Data.Models.Visit", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Visits");
                });

            modelBuilder.Entity("HealthCare.Data.Models.PatientVisit", b =>
                {
                    b.HasOne("HealthCare.Data.Models.Patient", "Patient")
                        .WithMany("PatientVisits")
                        .HasForeignKey("PatientId");

                    b.HasOne("HealthCare.Data.Models.PatientVisitStatus", "Status")
                        .WithMany()
                        .HasForeignKey("StatusId");

                    b.HasOne("HealthCare.Data.Models.Visit", "Visit")
                        .WithMany()
                        .HasForeignKey("VisitId");
                });
#pragma warning restore 612, 618
        }
    }
}
