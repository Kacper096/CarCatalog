﻿using CarCatalog.Database.Base;
using CarCatalog.Database.Entities;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace CarCatalog.Database
{
    public class CarCatalogContext : DbContext
    {
        public CarCatalogContext([NotNullAttribute] DbContextOptions options) : base(options)
        {
            this.ChangeTracker.StateChanged += OnChangeEntityTracker;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Car>(en =>
            {
                en.HasOne(c => c.Engine)
                    .WithMany(e => e.Cars)
                    .HasForeignKey(c => c.EngineId);

                en.HasOne(c => c.Category)
                    .WithMany(c => c.Cars)
                    .HasForeignKey(c => c.CategoryId);

                en.HasOne(c => c.Catalog)
                    .WithMany(c => c.Cars)
                    .HasForeignKey(c => c.CatalogId);
            });
            modelBuilder.Entity<Catalog>(en =>
               { 
                    en.HasOne(c => c.User)
                      .WithMany(u => u.Catalogs)
                      .HasForeignKey(c => c.UserId);
                });
            modelBuilder.Entity<User>().HasData(CarCatalogInitializer.SeedUsers());
            modelBuilder.Entity<Catalog>().HasData(CarCatalogInitializer.SeedCatalogs());
            modelBuilder.Entity<Category>().HasData(CarCatalogInitializer.SeedCategories());
            modelBuilder.Entity<Engine>().HasData(CarCatalogInitializer.SeedEngines());
            modelBuilder.Entity<Car>().HasData(CarCatalogInitializer.SeedCars());
        }

        private void OnChangeEntityTracker(object sender, EntityStateChangedEventArgs e)
        {
            if(e.Entry.Entity is Entity entity)
            {
                switch(e.Entry.State)
                {
                    case EntityState.Modified:
                        entity.UpdateDateEntity = DateTime.Now;
                        break;
                    case EntityState.Deleted:
                        e.Entry.State = EntityState.Modified;
                        entity.IsDeleted = true;
                        break;
                }
            }
        }
    }
}
