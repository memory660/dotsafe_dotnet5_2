﻿// <auto-generated />
using System;
using Com.Core.Dotsafe.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Com.Core.Dotsafe.Infrastructure.Migrations
{
    [DbContext(typeof(DotsafesContext))]
    [Migration("20220423080638_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.16");

            modelBuilder.Entity("Com.Core.Dotsafe.Domain.Contribution", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("ProjectId")
                        .HasColumnType("int");

                    b.Property<int?>("TechnoId")
                        .HasColumnType("int");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("name")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("ProjectId");

                    b.HasIndex("TechnoId");

                    b.HasIndex("UserId");

                    b.ToTable("Contributions");
                });

            modelBuilder.Entity("Com.Core.Dotsafe.Domain.Project", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("name")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("Com.Core.Dotsafe.Domain.Techno", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("name")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Technos");
                });

            modelBuilder.Entity("Com.Core.Dotsafe.Domain.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("email")
                        .HasColumnType("longtext");

                    b.Property<string>("password")
                        .HasColumnType("longtext");

                    b.Property<string>("roles")
                        .HasColumnType("longtext");

                    b.Property<string>("username")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Com.Core.Dotsafe.Domain.Contribution", b =>
                {
                    b.HasOne("Com.Core.Dotsafe.Domain.Project", "Project")
                        .WithMany("Contributions")
                        .HasForeignKey("ProjectId");

                    b.HasOne("Com.Core.Dotsafe.Domain.Techno", "Techno")
                        .WithMany("Contributions")
                        .HasForeignKey("TechnoId");

                    b.HasOne("Com.Core.Dotsafe.Domain.User", "User")
                        .WithMany("Contributions")
                        .HasForeignKey("UserId");

                    b.Navigation("Project");

                    b.Navigation("Techno");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Com.Core.Dotsafe.Domain.Project", b =>
                {
                    b.Navigation("Contributions");
                });

            modelBuilder.Entity("Com.Core.Dotsafe.Domain.Techno", b =>
                {
                    b.Navigation("Contributions");
                });

            modelBuilder.Entity("Com.Core.Dotsafe.Domain.User", b =>
                {
                    b.Navigation("Contributions");
                });
#pragma warning restore 612, 618
        }
    }
}
