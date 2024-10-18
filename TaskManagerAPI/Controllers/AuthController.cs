using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(UserDTO userDTO)
    {
        var result = await _authService.Register(userDTO);
        if (!result.Succeeded)
        {
            return BadRequest(result.Errors);
        }

        return Ok(result);
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(UserDTO userDTO)
    {
        var token = await _authService.Login(userDTO);
        if (token == null)
        {
            return Unauthorized();
        }

        return Ok(new { Token = token });
    }
}
