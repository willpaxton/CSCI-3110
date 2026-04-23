namespace Lab5WPBookAuthorApp.Services;

using Lab5WPBookAuthorApp.Models.Entities;

public interface IBookRepository
{
    Task<List<Book>> ReadAllAsync();
    Task<Book?> ReadAsync(int id);
}