using System;
using Microsoft.EntityFrameworkCore;
using CSCI3110WPLab2CRRUD.Models.Entities;
namespace CSCI3110WPLab2CRRUD.Services;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>().HasData(
            new Product { Id=1, Name="Apple", Price=1.23M, WeightInPounds=1, ManufactureDate=DateTime.Parse("2/5/2026"), InStock=true }
        );
    }

    public DbSet<Product> Products => Set<Product>();
}