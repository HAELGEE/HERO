using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HERO.Models;
internal class MyDbContext : DbContext
{
    public DbSet<Hero> Hero { get; set; }
    public DbSet<Armor> Armor { get; set; }
    public DbSet<Weapon> Weapon { get; set; }
    public DbSet<MeleeSkill> MeleeSkill { get; set; }
    public DbSet<RangeSkill> RangeSkill { get; set; }
    public DbSet<MageSkill> MageSkill { get; set; }
    public DbSet<User> User { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=HERO;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Hero>()
            .HasIndex(c => c.Username)
            .IsUnique();
        base.OnModelCreating(modelBuilder);

        //modelBuilder.Entity<ProductSubcategory>()
        //    .HasOne(ps => ps.ProductCategory)
        //    .WithMany(pc => pc.ProductSubcategories)
        //    .HasForeignKey(ps => ps.ProductCategoryId)
        //    .OnDelete(DeleteBehavior.Cascade);

        //modelBuilder.Entity<Shop>()
        //    .HasOne(s => s.ProductCategory)
        //    .WithMany(pc => pc.Shop)
        //    .HasForeignKey(s => s.ProductCategoryId)
        //    .OnDelete(DeleteBehavior.Cascade);

        //modelBuilder.Entity<Order>()
        //     .HasOne(o => o.Customer)
        //     .WithMany(c => c.Order)
        //     .HasForeignKey(o => o.CustomerId)
        //     .OnDelete(DeleteBehavior.SetNull);
    }
}
