namespace Library.WebApi.Controllers;

[ApiController]
[Authorize]
[ApiVersion("2.0")]
[Route("v1/books")]
public class BookController : ControllerBase
{
    private readonly IMediator _mediator;
    
    public BookController(IMediator mediator)
        =>  _mediator = mediator;
    
    [HttpGet]
    public async Task<ActionResult<ResultViewModel<IEnumerable<Book>>>> Get()
    {
        var result = await _mediator.Send(new ListBooksQuery(), cancellationToken: default);
        return Ok(result);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        var result = await _mediator.Send(new GetBookQuery(id));
        return Ok((result));
    }

    [HttpPost]
    public async Task<ActionResult<Guid>> Post([FromBody] CreateBookCommand command)
    {
        var result = await _mediator.Send(command);
        return Created($"{result}", result.Data);
    }

    [HttpPut("{id:guid}")]
    public async Task<ActionResult> Put(Guid id, [FromBody] UpdateBookCommand command)
    {
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        var command = new DeleteBookCommand(id);
        await _mediator.Send(command);
        return NoContent();
    }
}
