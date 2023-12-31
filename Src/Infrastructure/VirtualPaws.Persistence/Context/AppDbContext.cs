﻿using Microsoft.EntityFrameworkCore;
using VirtualPaws.Domain.Entities;
using VirtualPaws.Domain.RecordEntities;

namespace VirtualPaws.Persistence.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        { }
        #region EntityDbSet
        public DbSet<User> Users { get; set; }
        public DbSet<Pet> Pets { get; set; }
        public DbSet<PetFood> PetFoods { get; set; }
        public DbSet<Activity> Activitys { get; set; }
        public DbSet<PetHealtStatus> PetHealtStatuses { get; set; }
        public DbSet<Training> Trainings { get; set; }
        public DbSet<ActivityPet> ActivityPet { get; set; }
        #endregion
        #region RecordEntityDbSet
        public DbSet<OwnershipRecord> OwnershipRecords { get; set; }
        public DbSet<TrainingRecord> TrainingRecords { get; set; }
        public DbSet<FeedRecord> FeedRecords { get; set; }
        public DbSet<ActivityRecord> ActivityRecords { get; set; }
        #endregion
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ActivityPet>()
                .HasKey(bc => new { bc.PetId, bc.ActivityId });

            modelBuilder.Entity<ActivityPet>()
                .HasOne(bc => bc.Pet)
                .WithMany(b => b.ActivityPets)
                .HasForeignKey(bc => bc.PetId);

            modelBuilder.Entity<ActivityPet>()
                .HasOne(bc => bc.Activity)
                .WithMany(c => c.ActivityPets)
                .HasForeignKey(bc => bc.ActivityId);
        }
    }
}
