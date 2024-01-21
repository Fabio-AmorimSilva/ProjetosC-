namespace Library.WebApi.Controllers;

[ApiController]
[Authorize]
[ApiVersion("2.0")]
[Route("v1/author")]
public class AuthorController : ControllerBase
{
    private readonly IMediator _mediator;
    
    public AuthorController(IMediator mediator)
        =>  _mediator = mediator;
    
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<ResultViewModel<IEnumerable<Author>>>> Get()
    {
        var result = await _mediator.Send(new ListAuthorsQuery());
        return Ok(result); 
    }

    [HttpGet("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<ResultViewModel<Author>>> GetById(Guid id)
    {
        var result = await _mediator.Send(new GetAuthorQuery(id));
        return Ok(result);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    public async Task<ActionResult<Guid>> Post([FromBody] CreateAuthorCommand command)
    {
        var result = await _mediator.Send(command);
        return Created($"{result.Data}", result);
    }

    [HttpPut("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ActionResult> Put(Guid id, [FromBody] UpdateAuthorCommand command)
    {
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ActionResult> Delete(Guid id)
    {
        var command = new DeleteAuthorCommand(id);
        await _mediator.Send(command);
        return NoContent();
    }
}
