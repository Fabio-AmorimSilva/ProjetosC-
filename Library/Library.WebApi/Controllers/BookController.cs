namespace Library.WebApi.Controllers;

[ApiController]
[Authorize]
public class BookController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly LibraryContext _context;

    public BookController(
        LibraryContext context,
        IMediator mediator)
    {
        _context = context;
        _mediator = mediator;
    }

    [HttpGet("v1/books")]
    public async Task<ActionResult<ResultViewModel<IEnumerable<Book>>>> Get()
    {
        var books = await _context
            .Books
            .Include(b => b.Author)
            .Include(b => b.Library)
            .ToListAsync(cancellationToken: default);

        if(books is null)
            return NotFound(new ResultViewModel<IEnumerable<Book>>("No books found"));

        return Ok(new ResultViewModel<IEnumerable<Book>>(books));
    }

    [HttpGet("v1/books/{id:guid}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        var book = await _context.Books.FirstOrDefaultAsync(b => b.Id == id, cancellationToken: default);
        if (book is null)
            return NotFound(new ResultViewModel<Book>("Book not found"));

        return Ok(new ResultViewModel<Book>(book));
    }

    [HttpPost("v1/books")]
    public async Task<ActionResult<Guid>> Post([FromBody] CreateBookCommand command)
    {
        var result = await _mediator.Send(command);
        return Created($"{result}", result.Data);
    }

    [HttpPut("v1/books/{id:guid}")]
    public async Task<ActionResult> Put(Guid id, [FromBody] UpdateBookCommand command)
    {
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete("v1/books/{id:guid}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        var command = new DeleteBookCommand(id);
        await _mediator.Send(command);
        return NoContent();
    }
}
