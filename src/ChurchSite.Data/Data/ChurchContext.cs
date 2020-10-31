using ChurchSite.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChurchSite.Data.Data
{
    public class ChurchContext : DbContext
    {
        public ChurchContext(DbContextOptions<ChurchContext> options) : base(options)
        {
        }

        public DbSet<Church> Churches { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<Family> Families { get; set; }
        public DbSet<Membership> Memberships { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Family>()
                .HasOne(f => f.Father)
                .WithOne(p => p.FatherOf)
                .HasForeignKey<Person>(p => p.FatherOfId);

            modelBuilder.Entity<Person>()
                .HasOne(p => p.FatherOf)
                .WithOne(f => f.Father)
                .HasForeignKey<Family>(f => f.FatherId);

            modelBuilder.Entity<Family>()
                .HasOne(f => f.Mother)
                .WithOne(p => p.MotherOf)
                .HasForeignKey<Person>(p => p.MotherOfId);

            modelBuilder.Entity<Person>()
                .HasOne(p => p.MotherOf)
                .WithOne(f => f.Mother)
                .HasForeignKey<Family>(f => f.MotherId);

            modelBuilder.Entity<Person>()
                .HasOne(p => p.ChildOf)
                .WithMany(f => f.Children)
                .HasForeignKey(p => p.ChildOfId);
        }
    }
}
