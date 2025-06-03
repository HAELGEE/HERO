using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HERO.Models;
internal class MyDbContext : DbContext
{
    public DbSet<User> User { get; set; }
    public DbSet<Hero> Hero { get; set; }
    public DbSet<Enemy> Enemy { get; set; }
    public DbSet<Armor> Armor { get; set; }
    public DbSet<EquipedArmor> EquipedArmor { get; set; }
    public DbSet<EquipedWeapon> EquipedWeapon { get; set; }
    public DbSet<MeleeSkill> MeleeSkill { get; set; }
    public DbSet<RangeSkill> RangeSkill { get; set; }
    public DbSet<MageSkill> MageSkill { get; set; }
    public DbSet<Title> Title { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Game-Hero;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Sätter dessa till Unique så man inte kan skapa fler av samma
        modelBuilder.Entity<User>()
           .HasIndex(c => c.Email)
           .IsUnique();
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Hero>()
            .HasIndex(c => c.Username)
            .IsUnique();
        base.OnModelCreating(modelBuilder);


        // Delete when Hero is deleted.
        modelBuilder.Entity<Armor>()
            .HasOne(ps => ps.Hero)
            .WithMany(h => h.ArmorToEquip)
            .HasForeignKey(ps => ps.HeroId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Weapon>()
             .HasOne(ps => ps.Hero)
             .WithMany(h => h.WeaponToEquip)
             .HasForeignKey(ps => ps.HeroId)
             .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<EquipedArmor>()
            .HasOne(ps => ps.Hero)
            .WithMany(h => h.EquipedArmor)
            .HasForeignKey(ps => ps.HeroId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<EquipedWeapon>()
             .HasOne(ps => ps.Hero)
             .WithMany(h => h.EquipedWeapon)
             .HasForeignKey(ps => ps.HeroId)
             .OnDelete(DeleteBehavior.Cascade);
    }
}
