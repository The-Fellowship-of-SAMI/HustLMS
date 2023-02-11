using LetterManagement.Server.Models;
using LetterManagement.Server.Repositories;
using LetterManagement.Server.Services;
using LetterManagement.Shared.Dtos;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace LetterManagement.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AccountController : ControllerBase
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly DataContext _context;
    private readonly TokenService _tokenService;

    public AccountController(UserManager<ApplicationUser> userManager, DataContext context, TokenService tokenService)
    {
        _userManager = userManager;
        _context = context;
        _tokenService = tokenService;
    }

    [HttpPost("login")]
    public async Task<ActionResult<AppUserDto>> Login(LoginDto loginDto)
    {
        var user = await _userManager.FindByEmailAsync(loginDto.Email);
        if (user is null) return Unauthorized();
        var checkResult = await _userManager.CheckPasswordAsync(user, loginDto.Password);

        if (!checkResult)
        {
            return Unauthorized();
        }

        return new AppUserDto()
        {
            Email = user.Email,
            Role = user.Role,
            Token = _tokenService.CreateToken(user),
            UserId = user.UserId
        };

    }
}