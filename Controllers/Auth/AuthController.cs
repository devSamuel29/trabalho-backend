using Request.Auth;
using Repositories.Auth.Abstractions;

using Microsoft.AspNetCore.Mvc;

namespace PROJETO.Api.Controllers.Auth;

[ApiController]
[Route("[controller]")]
public class AuthController : ControllerBase
{
    private readonly IAuthRepository _repository;

    public AuthController(IAuthRepository repository)
    {
        _repository = repository;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequest request)
    {
        try
        {
            return Ok(await _repository.Login(request));
        }
        catch (Exception e)
        {
            return StatusCode(500, $"SERVER ERROR: {e.Message}");
        }
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterRequest request)
    {
        try
        {
            await _repository.Register(request);
            return NoContent();
        }
        catch (Exception)
        {
            return StatusCode(500, $"SERVER ERROR");
        }
    }
}
