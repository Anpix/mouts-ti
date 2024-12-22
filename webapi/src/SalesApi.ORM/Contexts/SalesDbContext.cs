﻿using Microsoft.EntityFrameworkCore;
using SalesApi.Domain.Entities;
using System.Reflection;

namespace SalesApi.ORM.Contexts;

public class SalesDbContext : DbContext
{
    public static readonly string Schema = "sales";

    public DbSet<Sale> Sales { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Discount> Discounts { get; set; }

    public SalesDbContext(DbContextOptions<SalesDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema(Schema);

        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(modelBuilder);
    }
}