namespace Library.WebApi.Controllers;

[ApiController]
[Route("v1/accounts")]
public class AccountsController : ControllerBase
{
    private readonly IMediator _mediator;
    
    public AccountsController(IMediator mediator)
        =>  _mediator = mediator;
    
    [HttpPost("signup")]
    public async Task<ActionResult> Signup([FromBody] SignupCommand command)
    {
        var result = await _mediator.Send(command);
        return Created($"{result}", result);
    }

    [HttpPost("login")]
    public async Task<ActionResult<ResultViewModel<string>>> Login([FromBody] LoginCommand command)
    {
        var result = await _mediator.Send(command);
        return Ok(result);
    }
}
