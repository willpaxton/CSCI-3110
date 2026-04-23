namespace Lab5WPBookAuthorApp.Services;

using Microsoft.EntityFrameworkCore;
using Lab5WPBookAuthorApp.Models.Entities;

public class DbBookRepository : IBookRepository
{
    private readonly ApplicationDbContext _context;

    public DbBookRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<Book>> ReadAllAsync()
    {
        return await _context.Books
            .Include(b => b.Authors)
            .ToListAsync();
    }

    public async Task<Book?> ReadAsync(int id)
    {
        return await _context.Books
            .Include(b => b.Authors)
            .FirstOrDefaultAsync(b => b.Id == id);
    }
}