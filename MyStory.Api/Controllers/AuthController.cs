using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyStory.DTOs.Dtos.UserDtos;
using MyStory.Service.Exceptions.UserExceptions;
using MyStory.Service.Interfaces;

namespace MyStory.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController(IUserService userService) : ControllerBase
{
    private readonly IUserService userService = userService;

    [HttpPost("register")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> RegisterAsync([FromBody] RegisterUserDto dto)
    {
        try
        {
            await userService.RegisterAsync(dto);
            return Ok();
        }
        catch (UserNullException ex)
        {
            return BadRequest(ex.TitleMessage);
        }
        catch (UserBadRequestException ex)
        {
            return StatusCode(500, ex.TitleMessage);
        }
    }

    [HttpPost("login")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> LoginAsync(LoginUserDto dto)
    {
        try
        {
            var result = await userService.LoginAsync(dto);
            return Ok(result);
        }
        catch (UserNotFoundException ex)
        {
            return NotFound(ex.TitleMessage);
        }
        catch (UserBadRequestException ex)
        {
            return BadRequest(ex.TitleMessage);
        }
    }

    [HttpPut("change-password")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> ChangePassword(ChangePasswordDto dto)
    {
        try
        {
            await userService.ChangePasswordAsync(dto);
            return Ok();
        }
        catch(UserBadRequestException ex)
        {
            return NotFound(ex.TitleMessage);
        }
        catch(Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
