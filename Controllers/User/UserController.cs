using Microsoft.AspNetCore.Mvc;
using Repositories.User.Abstractions;
using Request.User;

namespace Controllers.User;

[ApiController]
[Route("[controller]")]
public sealed class UserController : ControllerBase
{
    private readonly IUserRepository _repository;

    public UserController(IUserRepository repository)
    {
        _repository = repository;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetUserById([FromRoute] int id)
    {
        try
        {
            return Ok(await _repository.GetUserByIdAsync(id));
        }
        catch (Exception e)
        {
            return StatusCode(500, $"{e.Message} sexo");
        }
    }
    
    [HttpPut("update-user-data")]
    public async Task<IActionResult> UpdateUserById([FromBody] UpdateUserRequest request)
    {
        try
        {
            return Ok(await _repository.UpdateUserByIdAsync(request));
        }
        catch (Exception)
        {
            return StatusCode(500, "SERVER ERROR");
        }
    }
}
