using JwtRoleAuthentication.Application.DTOs;
using JwtRoleAuthentication.Application.Interfaces.Services;
using JwtRoleAuthentication.Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace JwtRoleAuthentication.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly ITokenService _tokenService;
    private readonly IUserService _userService;


    public UsersController(UserManager<ApplicationUser> userManager,
        ITokenService tokenService, IUserService userService, ILogger<UsersController> logger)
    {
        _userManager = userManager;
        _tokenService = tokenService;
        _userService = userService;
    }


    [HttpPost]
    [Route("register")]
    public async Task<IActionResult> Register(RegistrationRequest request)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var result = await _userService.CreateAsync(request);
        
        if (result.Succeeded)
        {
            request.Password = "";
            return CreatedAtAction(nameof(Register), new { email = request.Email}, request);
        }

        foreach (var error in result.Errors)
        {
            ModelState.AddModelError(error.Code, error.Description);
        }

        return BadRequest(ModelState);
    }


    [HttpPost]
    [Route("login")]
    public async Task<ActionResult<AuthResponse>> Authenticate([FromBody] AuthRequest request)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var result = _userService.Authenticate(request);

        return Ok(result);
    }
}