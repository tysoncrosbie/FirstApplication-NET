using Api.Dtos.Account;
using Api.Interfaces;
using Api.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AccountController : ControllerBase
{
    private readonly SignInManager<AppUser> _signinManager;
    private readonly ITokenService _tokenService;
    private readonly UserManager<AppUser> _userManager;

    public AccountController(UserManager<AppUser> userManager,
        ITokenService tokenService,
        SignInManager<AppUser> signInManager)
    {
        _userManager = userManager;
        _tokenService = tokenService;
        _signinManager = signInManager;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginUser loginUser)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var user = await _userManager.Users.FirstOrDefaultAsync(x => x.UserName == loginUser.Username.ToLower());

        if (user == null) return Unauthorized("Invalid username!");

        var result = await _signinManager.CheckPasswordSignInAsync(user, loginUser.Password, false);

        if (!result.Succeeded) return Unauthorized("Username not found and/or password incorrect");

        return Ok(
            new CreateNewUser
            {
                UserName = user.UserName,
                Email = user.Email,
                Token = _tokenService.CreateToken(user)
            }
        );
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterUser registerUser)
    {
        try
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var appUser = new AppUser
            {
                UserName = registerUser.Username,
                Email = registerUser.Email
            };

            if (registerUser.Password != null)
            {
                var createdUser = await _userManager.CreateAsync(appUser, registerUser.Password);

                if (!createdUser.Succeeded) return StatusCode(500, createdUser.Errors);
            }

            var roleResult = await _userManager.AddToRoleAsync(appUser, "User");

            if (roleResult.Succeeded)
                return Ok(
                    new CreateNewUser
                    {
                        UserName = appUser.UserName,
                        Email = appUser.Email,
                        Token = _tokenService.CreateToken(appUser)
                    }
                );
            return StatusCode(500, roleResult.Errors);
        }
        catch (Exception e)
        {
            return StatusCode(500, e);
        }
    }
}