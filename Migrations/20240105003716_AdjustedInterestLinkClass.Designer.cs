﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Mini_project_API.Data;

#nullable disable

namespace Mini_project_API.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20240105003716_AdjustedInterestLinkClass")]
    partial class AdjustedInterestLinkClass
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.25")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("InterestPerson", b =>
                {
                    b.Property<int>("InterestsId")
                        .HasColumnType("int");

                    b.Property<int>("PersonsId")
                        .HasColumnType("int");

                    b.HasKey("InterestsId", "PersonsId");

                    b.HasIndex("PersonsId");

                    b.ToTable("InterestPerson");
                });

            modelBuilder.Entity("Mini_project_API.Models.Interest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Interests");
                });

            modelBuilder.Entity("Mini_project_API.Models.InterestLink", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("InterestId")
                        .HasColumnType("int");

                    b.Property<int?>("PersonId")
                        .HasColumnType("int");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("InterestId");

                    b.HasIndex("PersonId");

                    b.ToTable("InterestLinks");
                });

            modelBuilder.Entity("Mini_project_API.Models.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("People");
                });

            modelBuilder.Entity("InterestPerson", b =>
                {
                    b.HasOne("Mini_project_API.Models.Interest", null)
                        .WithMany()
                        .HasForeignKey("InterestsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Mini_project_API.Models.Person", null)
                        .WithMany()
                        .HasForeignKey("PersonsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Mini_project_API.Models.InterestLink", b =>
                {
                    b.HasOne("Mini_project_API.Models.Interest", "Interest")
                        .WithMany("InterestLinks")
                        .HasForeignKey("InterestId");

                    b.HasOne("Mini_project_API.Models.Person", "Person")
                        .WithMany("InterestLinks")
                        .HasForeignKey("PersonId");

                    b.Navigation("Interest");

                    b.Navigation("Person");
                });

            modelBuilder.Entity("Mini_project_API.Models.Interest", b =>
                {
                    b.Navigation("InterestLinks");
                });

            modelBuilder.Entity("Mini_project_API.Models.Person", b =>
                {
                    b.Navigation("InterestLinks");
                });
#pragma warning restore 612, 618
        }
    }
}
