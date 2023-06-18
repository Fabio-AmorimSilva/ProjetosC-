using Library.Application.ViewModels.Library;
using Library.Application.ViewModels.Result;
using Library.Domain.Entities;
using Library.Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Library.WebApi.Controllers;

[ApiController]
[Authorize]
public class LibraryController : ControllerBase
{
    private readonly LibraryContext _context;

    public LibraryController(LibraryContext context)
    {
        _context = context;
    }

    [HttpGet("v1/library")]
    public async Task<IActionResult> Get()
    {
        var libraries = await _context
            .Libraries
            .Include(l => l.Books)
            .ToListAsync(cancellationToken: default);

        if(libraries is null)
            return NotFound(new ResultViewModel<LibraryUnit>("There are no libraries"));

        return Ok(new ResultViewModel<List<LibraryUnit>>(libraries));
    }

    [HttpGet("v1/library/{id:guid}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        var libraryUnit = await _context.Libraries.FirstOrDefaultAsync(l => l.Id == id, cancellationToken: default);
        if (libraryUnit is null)
            return NotFound(new ResultViewModel<LibraryUnit>("Library unit not found"));

        return Ok(new ResultViewModel<LibraryUnit>(libraryUnit));
    }

    [HttpPost("v1/library")]
    public async Task<IActionResult> Post([FromBody] LibraryUnitRequestViewModel libraryUnit)
    { 
        var libraryUnitFromDatabase = await _context
            .Libraries
            .FirstOrDefaultAsync(l => l.Name == libraryUnit.Name && l.City == libraryUnit.City, cancellationToken: default);

        if (libraryUnitFromDatabase is not null)
            return NotFound(new ResultViewModel<LibraryUnit>("Library unit already exists. Please enter a new one"));

        var newLibraryUnit = new LibraryUnit(
            libraryUnit.Name, 
            libraryUnit.City);

        await _context.Libraries.AddAsync(newLibraryUnit);
        await _context.SaveChangesAsync();

        return Created($"{newLibraryUnit.Name}", newLibraryUnit);
    }

    [HttpPut("v1/library/{id:guid}")]
    public async Task<IActionResult> Put([FromBody] LibraryUnitRequestViewModel libraryUnit, [FromRoute] Guid id)
    {
        var libraryUnitFromDatabase = await _context.Libraries.FirstOrDefaultAsync(l => l.Id == id, cancellationToken: default);
        if (libraryUnitFromDatabase is null)
            return NotFound(new ResultViewModel<LibraryUnit>("Library unit not found"));

        libraryUnitFromDatabase.Name = libraryUnit.Name;
        libraryUnitFromDatabase.City = libraryUnit.City;

        _context.Libraries.Update(libraryUnitFromDatabase);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    [HttpDelete("v1/library/{id:guid}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        var libraryFromDatabase = await _context.Libraries.FirstOrDefaultAsync(l => l.Id == id, cancellationToken: default);
        if (libraryFromDatabase is null)
            return NotFound(new ResultViewModel<LibraryUnit>("Library unit not found"));

        _context.Libraries.Remove(libraryFromDatabase);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}
