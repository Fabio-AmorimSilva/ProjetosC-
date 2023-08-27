namespace Library.WebApi.Controllers;

[ApiController]
[Authorize]
[Route("v1/author")]
public class AuthorController : ControllerBase
{
    private readonly IMediator _mediator;
    
    public AuthorController(IMediator mediator)
        =>  _mediator = mediator;
    
    [HttpGet]
    public async Task<ActionResult<ResultViewModel<IEnumerable<Author>>>> Get()
    {
        var result = await _mediator.Send(new ListAuthorsQuery());
        return Ok(result); 
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<ResultViewModel<Author>>> GetById(Guid id)
    {
        var result = await _mediator.Send(new GetAuthorQuery(id));
        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult<Guid>> Post([FromBody] CreateAuthorCommand command)
    {
        var result = await _mediator.Send(command);
        return Created($"{result.Data}", result);
    }

    [HttpPut("{id:guid}")]
    public async Task<ActionResult> Put(Guid id, [FromBody] UpdateAuthorCommand command)
    {
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    public async Task<ActionResult> Delete(Guid id)
    {
        var command = new DeleteAuthorCommand(id);
        await _mediator.Send(command);
        return NoContent();
    }
}
