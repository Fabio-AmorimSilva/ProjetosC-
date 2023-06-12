using Microsoft.AspNetCore.Mvc;

namespace Library.WebApi.Controllers;

[ApiController]
public class AccountsController : ControllerBase
{
    [HttpPost]
    public IActionResult Login([FromBody] ) 
}
