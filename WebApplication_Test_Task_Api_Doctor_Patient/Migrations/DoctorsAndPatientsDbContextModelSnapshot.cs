// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApplication_Test_Task_Api_Doctor_Patient.Models.DbContextModels;

#nullable disable

namespace WebApplication_Test_Task_Api_Doctor_Patient.Migrations
{
    [DbContext(typeof(DoctorsAndPatientsDbContext))]
    partial class DoctorsAndPatientsDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("WebApplication_Test_Task_Api_Doctor_Patient.Models.Cabinet", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Cabinets");
                });

            modelBuilder.Entity("WebApplication_Test_Task_Api_Doctor_Patient.Models.District", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Districts");
                });

            modelBuilder.Entity("WebApplication_Test_Task_Api_Doctor_Patient.Models.Doctor", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CabinetId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("DistrictId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("FullName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("SpecializationId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("CabinetId");

                    b.HasIndex("DistrictId");

                    b.HasIndex("SpecializationId");

                    b.ToTable("Doctors");
                });

            modelBuilder.Entity("WebApplication_Test_Task_Api_Doctor_Patient.Models.Patient", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("DistrictId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Gender")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MiddleName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DistrictId");

                    b.ToTable("Patients");
                });

            modelBuilder.Entity("WebApplication_Test_Task_Api_Doctor_Patient.Models.Specialization", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Specializations");
                });

            modelBuilder.Entity("WebApplication_Test_Task_Api_Doctor_Patient.Models.Doctor", b =>
                {
                    b.HasOne("WebApplication_Test_Task_Api_Doctor_Patient.Models.Cabinet", "Cabinet")
                        .WithMany()
                        .HasForeignKey("CabinetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApplication_Test_Task_Api_Doctor_Patient.Models.District", "District")
                        .WithMany()
                        .HasForeignKey("DistrictId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApplication_Test_Task_Api_Doctor_Patient.Models.Specialization", "Specialization")
                        .WithMany()
                        .HasForeignKey("SpecializationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cabinet");

                    b.Navigation("District");

                    b.Navigation("Specialization");
                });

            modelBuilder.Entity("WebApplication_Test_Task_Api_Doctor_Patient.Models.Patient", b =>
                {
                    b.HasOne("WebApplication_Test_Task_Api_Doctor_Patient.Models.District", "District")
                        .WithMany()
                        .HasForeignKey("DistrictId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("District");
                });
#pragma warning restore 612, 618
        }
    }
}
