namespace Library.WebApi.Controllers;

[ApiController]
[ApiVersion("2.0")]
[Route("v1/accounts")]
public class AccountsController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly ILogger<AccountsController> _logger;
    
    public AccountsController(
        IMediator mediator, 
        ILogger<AccountsController> logger
    )
    {
        _mediator = mediator;
        _logger = logger;
    }

    [HttpPost("signup")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    public async Task<ActionResult> Signup([FromBody] SignupCommand command)
    {
        var result = await _mediator.Send(command);
        return Created($"{result}", result);
    }

    [HttpPost("login")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
    public async Task<ActionResult<ResultViewModel<string>>> Login([FromBody] LoginCommand command)
    {
        var result = await _mediator.Send(command);
        _logger.LogInformation("Login is an success!!");
        return Ok(result);
    }
}
