using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IJwtTokenService _jwtTokenService;

    public AuthController(IJwtTokenService jwtTokenService)
    {
        _jwtTokenService = jwtTokenService;
    }

    [HttpPost("login")]
    public IActionResult Login(string username, string password)
    {
        // TODO: Replace with actual user (e.g., database check)
        if (username == "admin" && password == "password123")
        {
            var token = _jwtTokenService.GenerateToken(username);
            return Ok(new { Token = token });
        }
        return Unauthorized();
    }
}
