﻿// <auto-generated />
using System;
using DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DAL.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.11-servicing-32099")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BO.Models.RoleEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Role");
                });

            modelBuilder.Entity("BO.Models.TaskEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AssignedTo");

                    b.Property<string>("CreatedBy");

                    b.Property<string>("Description");

                    b.Property<DateTime?>("EndTime");

                    b.Property<bool>("IsAccepted");

                    b.Property<bool>("IsApproved");

                    b.Property<bool>("IsDone");

                    b.Property<int?>("Mark");

                    b.Property<string>("Name");

                    b.Property<string>("Note");

                    b.Property<DateTime?>("NoteTime");

                    b.Property<string>("Reason");

                    b.Property<DateTime>("StartTime");

                    b.Property<DateTime?>("UpdateTime");

                    b.Property<string>("Updateby");

                    b.HasKey("Id");

                    b.HasIndex("AssignedTo");

                    b.ToTable("Task");
                });

            modelBuilder.Entity("BO.Models.UserEntity", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Password");

                    b.Property<int>("RoleId");

                    b.Property<string>("UserName");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("User");
                });

            modelBuilder.Entity("BO.Models.UserManage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ManagedBy");

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("UserManage");
                });

            modelBuilder.Entity("BO.Models.TaskEntity", b =>
                {
                    b.HasOne("BO.Models.UserEntity", "User")
                        .WithMany("Task")
                        .HasForeignKey("AssignedTo");
                });

            modelBuilder.Entity("BO.Models.UserEntity", b =>
                {
                    b.HasOne("BO.Models.RoleEntity", "RoleEntity")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BO.Models.UserManage", b =>
                {
                    b.HasOne("BO.Models.UserEntity", "User")
                        .WithMany("UserManages")
                        .HasForeignKey("UserId");
                });
#pragma warning restore 612, 618
        }
    }
}
