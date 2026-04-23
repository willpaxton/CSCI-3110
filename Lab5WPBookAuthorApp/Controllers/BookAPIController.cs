using Microsoft.AspNetCore.Mvc;
using Lab5WPBookAuthorApp.Services;
using Lab5WPBookAuthorApp.Models.Entities;

namespace Lab5WPBookAuthorApp.Controllers;

[ApiController]
[Route("api/book")]
public class BookAPIController : ControllerBase
{
    private readonly IBookRepository _bookRepository;
    private readonly IAuthorRepository _authorRepository;

    public BookAPIController(IBookRepository bookRepository, IAuthorRepository authorRepository)
    {
        _bookRepository = bookRepository;
        _authorRepository = authorRepository;
    }

    [HttpGet("all")]
    public async Task<IActionResult> ReadAll()
    {
        var books = await _bookRepository.ReadAllAsync();
        return Ok(books);
    }

    [HttpGet("one/{id}")]
    public async Task<IActionResult> ReadOne(int id)
    {
        var book = await _bookRepository.ReadAsync(id);
        if (book == null) return NotFound();
        return Ok(book);
    }

    [HttpPost("author/add")]
    public async Task<IActionResult> AddAuthor([FromForm] int bookId, [FromForm] string? firstName, [FromForm] string lastName)
    {
        var author = new Author
        {
            FirstName = firstName,
            LastName = lastName
        };

        var savedAuthor = await _authorRepository.CreateAsync(bookId, author);

        var authorDTO = new
        {
            id = savedAuthor.Id,
            firstName = savedAuthor.FirstName,
            lastName = savedAuthor.LastName,
            bookId = savedAuthor.BookId
        };

        return Ok(authorDTO);
    }
}