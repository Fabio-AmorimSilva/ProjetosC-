using Library.Application.Commands.Library.CreateLibrary;
using Library.Application.Commands.Library.DeleteLibrary;
using Library.Application.Commands.Library.UpdateLibrary;
using Library.Application.Queries.Libraries.GetLibrary;
using Library.Application.Queries.Libraries.ListLibraries;

namespace Library.WebApi.Controllers;

[ApiController]
[Authorize]
[ApiVersion("2.0")]
[Route("v1/library")]
public class LibraryController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> Get()
    {
        var result = await mediator.Send(new ListLibrariesQuery());
        return Ok(result);
    }

    [HttpGet("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        var result = await mediator.Send(new GetLibraryQuery(id));
        return Ok(result);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
    public async Task<IActionResult> Post([FromBody] CreateLibraryCommand command)
    {
        var result = await mediator.Send(command);
        return Created($"{result.Data}", result);
    }

    [HttpPut("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Put(Guid id, [FromBody] UpdateLibraryCommand command)
    {
        await mediator.Send(command);
        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        var command = new DeleteLibraryCommand(id);
        await mediator.Send(command);
        return NoContent();
    }
}
