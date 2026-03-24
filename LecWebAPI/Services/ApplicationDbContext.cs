using Microsoft.EntityFrameworkCore;
using LecWebAPI.Models.Entities;

namespace LecWebAPI.Services;

public class ApplicationDbContext : DbContext 
{
    public ApplicationDbContext(DbContextOptions options) : base(options)
    {}

    public DbSet<Pet> Pets => Set<Pet>();
}