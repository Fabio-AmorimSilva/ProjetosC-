using Library.Application.Commands.Account.Login;
using Library.Application.Commands.Account.Signup;

namespace Library.WebApi.Controllers;

[ApiController]
[ApiVersion("2.0")]
[Route("v1/accounts")]
public class AccountsController(
    IMediator mediator,
    ILogger<AccountsController> logger
) : ControllerBase
{
    [HttpPost("signup")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    public async Task<ActionResult> Signup([FromBody] SignupCommand command)
    {
        var result = await mediator.Send(command);
        return Created($"{result}", result);
    }

    [HttpPost("login")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
    public async Task<ActionResult<ResultViewModel<string>>> Login([FromBody] LoginCommand command)
    {
        var result = await mediator.Send(command);
        logger.LogInformation("Login is an success!!");
        return Ok(result);
    }
}
