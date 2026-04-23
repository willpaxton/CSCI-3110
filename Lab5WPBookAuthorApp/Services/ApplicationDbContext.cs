using Microsoft.EntityFrameworkCore;
using Lab5WPBookAuthorApp.Models.Entities;

namespace Lab5WPBookAuthorApp.Services;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<Book> Books { get; set; }
    public DbSet<Author> Authors { get; set; }
}