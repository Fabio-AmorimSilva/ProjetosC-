using Library.Application.ViewModels.Authors;
using Library.Application.ViewModels.Result;
using Library.Domain.Entities;
using Library.Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Library.WebApi.Controllers;

[ApiController]
[Authorize]
public class AuthorController : ControllerBase
{
    private readonly LibraryContext _context;

    public AuthorController(LibraryContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> Get() 
    { 
        var authors = await _context
            .Authors
            .Include(a => a.Books)
            .ToListAsync(cancellationToken: default);

        if (authors is null)
            return NotFound(new ResultViewModel<List<Author>>("No authors found"));

        return Ok(new ResultViewModel<List<Author>>(authors)); 
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] AuthorViewModel author)
    {
        var authorFromDatabase = await _context
            .Authors
            .FirstOrDefaultAsync(a => a.Name == author.Name, cancellationToken: default);

        if (authorFromDatabase is not null)
            return NotFound(new ResultViewModel<Author>("Author already exists. Please enter another one"));

        var newAuthor = new Author(
            name: author.Name,
            country: author.Country,
            birth: author.Birth);

        await _context.Authors.AddAsync(newAuthor);
        await _context.SaveChangesAsync();

        return Created($"{newAuthor.Name}", newAuthor);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Put([FromBody] AuthorViewModel author, [FromRoute] Guid id)
    {
        var authorFromDatabase = await _context
            .Authors
            .FirstOrDefaultAsync(a => a.Id == id, cancellationToken: default);

        if (authorFromDatabase is null)
            return NotFound(new ResultViewModel<Author>("Author not found"));

        authorFromDatabase.Name = author.Name;
        authorFromDatabase.Country = author.Country;
        authorFromDatabase.Birth = author.Birth;

        _context.Authors.Update(authorFromDatabase);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        var authorFromDatabase = await _context
            .Authors
            .FirstOrDefaultAsync(a => a.Id == id, cancellationToken: default);

        if(authorFromDatabase is null)
            return NotFound(new ResultViewModel<Author>("Author not found"));

        _context.Authors.Remove(authorFromDatabase);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}
