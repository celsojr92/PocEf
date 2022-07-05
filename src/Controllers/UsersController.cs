using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PocEf.Data;
using PocEf.Models;
using PocEf.ViewModels;

namespace PocEf.Controllers;

[ApiController]
[Route("api/v1/users")]
public class UsersController : ControllerBase
{
    private readonly AppDbContext _appDbContext;

    public UsersController(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    [HttpGet]
    public async Task<IActionResult> GetAsync(
        CancellationToken cancellationToken)
    {
        var users = await _appDbContext
            .Users!
            .ToListAsync(cancellationToken);

        return Ok(users);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync(
        int id,
        CancellationToken cancellationToken)
    {
        var user = await _appDbContext
            .Users!
            .AsNoTracking()
            .FirstOrDefaultAsync(user => user.Id.Equals(id), cancellationToken);

        return user is null ? NotFound() : Ok(user);
    }

    [HttpPost]
    public async Task<IActionResult> PostAsync(
        [FromBody] CreateUserViewModel model,
        CancellationToken cancellationToken)
    {
        if (!ModelState.IsValid)
            return BadRequest();

        var user = new User
        {
            CreatedAt = DateTime.UtcNow,
            Name = model.Name,
            Email = model.Email
        };

        try
        {
            await _appDbContext.Users!.AddAsync(user, cancellationToken);
            await _appDbContext.SaveChangesAsync(cancellationToken);
        }
        catch
        {
            return BadRequest();
        }


        return Created($"api/v1/users/{user.Id}", user);
    }
}