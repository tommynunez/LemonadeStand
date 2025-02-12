using System;
using LemonadeStand.Abstractions.Entities;
using LemonadeStand.Data.Configurations;
using Microsoft.EntityFrameworkCore;
using LemonadeStand.Abstractions.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace LemonadeStand.Data
{
  public class DatabaseContext : DbContext, IMigratable
  {
    public static readonly ILoggerFactory MyLoggerFactory = LoggerFactory.Create(builder =>
    {
    });

    public IConfiguration Configuration { get; }
    public DbSet<LemonadeType> LemonadeTypes { get; set; }
    public DbSet<LineItem> LineItems { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Size> Sizes { get; set; }

    public DatabaseContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      if (!optionsBuilder.IsConfigured)
      {
        optionsBuilder
            .UseLoggerFactory(MyLoggerFactory)
            .UseSqlite(Configuration.GetSection("Database:local").Value);
      }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      base.OnModelCreating(modelBuilder);

      modelBuilder.ApplyConfiguration(new LineItemConfiguration());
      modelBuilder.ApplyConfiguration(new LemonadeTypeConfiguration());
      modelBuilder.ApplyConfiguration(new SizeConfiguration());
      modelBuilder.ApplyConfiguration(new ProductConfiguration());
      modelBuilder.ApplyConfiguration(new OrderConfiguration());
    }
  }
}

