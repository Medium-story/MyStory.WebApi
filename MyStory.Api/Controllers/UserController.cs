using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyStory.Service.Exceptions.UserExceptions;
using MyStory.Service.Interfaces;

namespace MyStory.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController(IUserService userService) : ControllerBase
{
    private readonly IUserService _userService = userService;

    [HttpGet("get-users")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> GetAll()
    {
        try
        {
            var users = await _userService.GetAllUsersAsync();
            return Ok(users);
        }
        catch (UserNotFoundException ex)
        {
            return StatusCode(204, ex.TitleMessage);
        }
    }

    [HttpGet("get-by-id")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetById(string id)
    {
        try
        {
            var user = await _userService.GetByIdUserAsync(id);
            return Ok(user);
        }
        catch (UserNullException ex)
        {
            return StatusCode(404, ex.TitleMessage);
        }
    }

}
