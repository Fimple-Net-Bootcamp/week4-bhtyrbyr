﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using VirtualPaws.Persistence.Context;

#nullable disable

namespace VirtualPaws.Persistence.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20231215175324_pet-table-update")]
    partial class pettableupdate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("ActivityPet", b =>
                {
                    b.Property<int>("ActivitiesCanBeId")
                        .HasColumnType("integer");

                    b.Property<int>("PawsId")
                        .HasColumnType("integer");

                    b.HasKey("ActivitiesCanBeId", "PawsId");

                    b.HasIndex("PawsId");

                    b.ToTable("ActivityPet");
                });

            modelBuilder.Entity("VirtualPaws.Domain.Entities.Activity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<byte>("NutritionalValue")
                        .HasColumnType("smallint");

                    b.HasKey("Id");

                    b.ToTable("Activities");
                });

            modelBuilder.Entity("VirtualPaws.Domain.Entities.OwnershipRecord", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("OwnerId")
                        .HasColumnType("integer");

                    b.Property<bool>("PawStatus")
                        .HasColumnType("boolean");

                    b.Property<int>("PetId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("OwnerId");

                    b.HasIndex("PetId");

                    b.ToTable("OwnershipRecords");
                });

            modelBuilder.Entity("VirtualPaws.Domain.Entities.Pet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<byte>("HungerStatus")
                        .HasColumnType("smallint");

                    b.Property<bool>("IsAlive")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsOwned")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsVisible")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("OwnerId")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("OwnershipDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<byte>("PawType")
                        .HasColumnType("smallint");

                    b.HasKey("Id");

                    b.HasIndex("OwnerId");

                    b.ToTable("Pets");
                });

            modelBuilder.Entity("VirtualPaws.Domain.Entities.PetFood", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<byte>("NutritionalValue")
                        .HasColumnType("smallint");

                    b.HasKey("Id");

                    b.ToTable("PetFoods");
                });

            modelBuilder.Entity("VirtualPaws.Domain.Entities.PetHealtStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<byte>("HealtScore")
                        .HasColumnType("smallint");

                    b.Property<int>("PetId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("PetId");

                    b.ToTable("PetHealtSituations");
                });

            modelBuilder.Entity("VirtualPaws.Domain.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("BirthDay")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<byte>("PetOwnershipAbility")
                        .HasColumnType("smallint");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("ActivityPet", b =>
                {
                    b.HasOne("VirtualPaws.Domain.Entities.Activity", null)
                        .WithMany()
                        .HasForeignKey("ActivitiesCanBeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("VirtualPaws.Domain.Entities.Pet", null)
                        .WithMany()
                        .HasForeignKey("PawsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("VirtualPaws.Domain.Entities.OwnershipRecord", b =>
                {
                    b.HasOne("VirtualPaws.Domain.Entities.User", "Owner")
                        .WithMany()
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("VirtualPaws.Domain.Entities.Pet", "Pet")
                        .WithMany()
                        .HasForeignKey("PetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Owner");

                    b.Navigation("Pet");
                });

            modelBuilder.Entity("VirtualPaws.Domain.Entities.Pet", b =>
                {
                    b.HasOne("VirtualPaws.Domain.Entities.User", "Owner")
                        .WithMany("Paws")
                        .HasForeignKey("OwnerId");

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("VirtualPaws.Domain.Entities.PetHealtStatus", b =>
                {
                    b.HasOne("VirtualPaws.Domain.Entities.Pet", "Pet")
                        .WithMany()
                        .HasForeignKey("PetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pet");
                });

            modelBuilder.Entity("VirtualPaws.Domain.Entities.User", b =>
                {
                    b.Navigation("Paws");
                });
#pragma warning restore 612, 618
        }
    }
}
