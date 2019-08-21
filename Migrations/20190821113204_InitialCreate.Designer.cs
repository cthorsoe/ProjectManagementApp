﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProjectManagementApp.Models.Data;

namespace ProjectManagementApp.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20190821113204_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("ProjectManagementApp.Models.Account", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("now()");

                    b.Property<DateTime>("LastEditedDate")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("now()");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Account");
                });

            modelBuilder.Entity("ProjectManagementApp.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("AccountId");

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("now()");

                    b.Property<string>("Email");

                    b.Property<string>("Hash");

                    b.Property<DateTime>("LastEditedDate")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("now()");

                    b.Property<string>("Salt");

                    b.Property<string>("Username")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("Username")
                        .IsUnique();

                    b.ToTable("User");
                });

            modelBuilder.Entity("ProjectManagementApp.Models.User", b =>
                {
                    b.HasOne("ProjectManagementApp.Models.Account", "Account")
                        .WithMany("Users")
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
