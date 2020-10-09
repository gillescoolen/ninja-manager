using System;
using Microsoft.EntityFrameworkCore;
using NinjaManager.Domain.Models;

namespace NinjaManager.Domain.Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        {
        }

        public DbSet<Ninja> Ninja { get; set; }
        public DbSet<Gear> Gear { get; set; }
        public DbSet<NinjaGear> NinjaGear { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Gear>()
                .Property(e => e.Slot)
                .HasConversion(
                    t => t.ToString(),
                    t => Enum.Parse<GearType>(t)
                );

            modelBuilder.Entity<Ninja>()
                .HasIndex(u => u.Name)
                .IsUnique();

            modelBuilder.Entity<Gear>()
                .HasIndex(u => u.Name)
                .IsUnique();

            modelBuilder.Entity<NinjaGear>()
                .HasKey(t => new {t.GearId, t.NinjaId});
        }
    }
}
