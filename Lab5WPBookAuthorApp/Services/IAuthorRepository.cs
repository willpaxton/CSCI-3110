using Lab5WPBookAuthorApp.Models.Entities;

namespace Lab5WPBookAuthorApp.Services;

public interface IAuthorRepository
{
    Task<Author> CreateAsync(int bookId, Author author);
}