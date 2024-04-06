﻿using Library.Application.Commands.Book.CreateBook;
using Library.Application.Commands.Book.DeleteBook;
using Library.Application.Commands.Book.UpdateBook;
using Library.Application.Commands.Book.UpdateBookAuthor;
using Library.Application.Commands.Book.UpdateBookLibrary;
using Library.Application.Queries.Books.GetBook;
using Library.Application.Queries.Books.ListBooks;

namespace Library.WebApi.Controllers;

[ApiController]
[Authorize]
[ApiVersion("2.0")]
[Route("v1/books")]
public class BookController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<ResultViewModel<IEnumerable<Book>>>> Get()
    {
        var result = await mediator.Send(new ListBooksQuery(), cancellationToken: default);
        return Ok(result);
    }

    [HttpGet("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        var result = await mediator.Send(new GetBookQuery(id));
        return Ok((result));
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    public async Task<ActionResult<Guid>> Post([FromBody] CreateBookCommand command)
    {
        var result = await mediator.Send(command);
        return Created($"{result}", result.Data);
    }

    [HttpPut("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ActionResult> Put(Guid id, [FromBody] UpdateBookCommand command)
    {
        await mediator.Send(command);
        return NoContent();
    }
    
    [HttpPut("{id:guid}/author/{authorId:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> UpdateBookAuthor(Guid authorId, [FromBody] UpdateBookAuthorCommand command)
    {
        await mediator.Send(command);
        return NoContent();
    }
    
    [HttpPut("{authorId:guid}/library/{libraryId:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> UpdateBookLibrary(Guid libraryId, Guid authorId, [FromBody] UpdateBookLibraryCommand command)
    {
        await mediator.Send(command);
        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        var command = new DeleteBookCommand(id);
        await mediator.Send(command);
        return NoContent();
    }
}
