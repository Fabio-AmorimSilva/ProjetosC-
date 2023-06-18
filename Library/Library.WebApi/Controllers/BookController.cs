using Library.Application.ViewModels.Books;
using Library.Application.ViewModels.Result;
using Library.Domain.Entities;
using Library.Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Library.WebApi.Controllers;

[ApiController]
[Authorize]
public class BookController : ControllerBase
{
    private readonly LibraryContext _context;

    public BookController(LibraryContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var books = await _context
            .Books
            .Include(b => b.Author)
            .Include(b => b.Library)
            .ToListAsync(cancellationToken: default);
        if(books is null)
            return NotFound(new ResultViewModel<List<Book>>("No books found"));

        return Ok(new ResultViewModel<List<Book>>(books));
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        var book = await _context.Books.FirstOrDefaultAsync(b => b.Id == id, cancellationToken: default);
        if (book is null)
            return NotFound(new ResultViewModel<Book>("Book not found"));

        return Ok(new ResultViewModel<Book>(book));
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] BookViewModel book)
    {
        var bookFromDatabase = _context
            .Books
            .Include(b => b.Author)
            .FirstOrDefaultAsync(b => b.Title == book.Title && b.Author!.Name == book.Author!.Name, cancellationToken: default);

        if(bookFromDatabase is not null)
            return BadRequest(new ResultViewModel<Book>("Book already exists. Please enter another book"));

        var newBook = new Book(
            title: book.Title,
            year: book.Year,
            pages : book.Pages,
            authorId: book.AuthorId,
            libraryId: book.LibraryId,
            genre: book.Genre);

        await _context.Books.AddAsync(newBook);
        await _context.SaveChangesAsync();

        return Created($"{newBook.Id}", newBook);
    }

    [HttpPut("id:guid")]
    public async Task<IActionResult> Put([FromBody] BookViewModel book, [FromRoute] Guid id)
    {
        var bookFromDatabase = await _context
            .Books
            .FirstOrDefaultAsync(b => b.Id == id, cancellationToken: default);

        if (bookFromDatabase is null)
            return NotFound(new ResultViewModel<Book>("Book not found."));

        bookFromDatabase.Title = book.Title;
        bookFromDatabase.Year = book.Year;
        bookFromDatabase.Pages = book.Pages;
        bookFromDatabase.AuthorId = book.AuthorId;
        bookFromDatabase.LibraryId = book.LibraryId;
        bookFromDatabase.Genre = book.Genre;

        _context.Books.Update(bookFromDatabase);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    [HttpDelete("id:guid")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        var bookFromDatabase = await _context
            .Books
            .FirstOrDefaultAsync(b => b.Id == id, cancellationToken: default);

        if (bookFromDatabase is null)
            return NotFound(new ResultViewModel<Book>("Book not found"));

        _context.Books.Remove(bookFromDatabase);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}
