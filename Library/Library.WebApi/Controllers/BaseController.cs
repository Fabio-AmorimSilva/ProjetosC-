namespace Library.WebApi.Controllers;

public class BaseController(IMediator mediator) : ControllerBase
{
    protected readonly IMediator _mediator = mediator;
}