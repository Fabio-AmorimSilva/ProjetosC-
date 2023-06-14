using Library.Application.ViewModels.Result;
using Library.Application.ViewModels.User;
using Library.Domain.Entities;
using Library.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Library.WebApi.Controllers;

[ApiController]
public class AccountsController : ControllerBase
{

    private readonly LibraryContext _context;

    public AccountsController(LibraryContext context)
    {
        _context = context;
    }

    [HttpPost("v1/accounts/signup")]
    public async Task<IActionResult> Login([FromBody] RegisterViewModel register)
    {
        var userExists = await _context
            .Users
            .FirstOrDefaultAsync(u => u.Email == register.Email, cancellationToken:default);

        if(userExists is not null)
            return BadRequest(new ResultViewModel<User>("Email alerady used"));


        var user = new User(
            name: register.Name,
            email: register.Email,
            password: register.Password,
            role: register.Role);

        await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();

        return Created($"{user.Name}", user);
    } 
}
