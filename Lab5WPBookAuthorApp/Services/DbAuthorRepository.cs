using Microsoft.EntityFrameworkCore;
using Lab5WPBookAuthorApp.Models.Entities;

namespace Lab5WPBookAuthorApp.Services;

public class DbAuthorRepository : IAuthorRepository
{
    private readonly ApplicationDbContext _context;

    public DbAuthorRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Author> CreateAsync(int bookId, Author author)
    {
        var book = await _context.Books.FindAsync(bookId);

        if (book != null)
        {
            author.Book = book;
            await _context.Authors.AddAsync(author);
            await _context.SaveChangesAsync();
        }

        return author;
    }
}