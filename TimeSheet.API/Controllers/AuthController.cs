using TimeSheet.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using TimeSheet.Application.DTOs;
using Microsoft.AspNetCore.Authorization;

namespace TimeSheet.API.Controllers;

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
    [Authorize(Policy = "AdminOnly")]
    public async Task<ActionResult> Register([FromBody] RegisterRequestDTO dto)
    {
        var result = await _authService.RegisterAsync(dto);

        return Ok(result);
    }

    [HttpPost("login")]
    public async Task<ActionResult> Login([FromBody] LoginRequestDTO dto)
    {
        var response = await _authService.LoginAsync(dto);

        return Ok(response);
    }
}
