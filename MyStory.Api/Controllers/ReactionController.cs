using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyStory.DTOs.Dtos.ReactionDtos;
using MyStory.Service.Exceptions.ReactionRxception;
using MyStory.Service.Exceptions.TagExceptions;
using MyStory.Service.Interfaces;
using MyStory.Service.Services;

namespace MyStory.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ReactionController(IReactionService reactionService) : ControllerBase
{
    private readonly IReactionService _reactionService = reactionService;

    [HttpPost("add-reactive")]
    //[Authorize(Roles = "SuperAdmin, Admin")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> AddReaction(AddReactionDto reactionDto)
    {
        try
        {
            await _reactionService.CreateAsync(reactionDto);
            return Ok();
        }
        catch (ReactionNullException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (ReactionNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }

    [HttpGet("get-all-reaction")]
    //[Authorize(Roles = "SuperAdmin, Admin")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Getall()
    {
        try
        {
            var reactions = await _reactionService.GetAllAsync();
            return Ok(reactions);
        }
        catch (ReactionNullException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (ReactionNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }

    [HttpDelete("delete")]
    //[Authorize(Roles = "SuperAdmin, Admin")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            await _reactionService.DeleteAsync(id);
            return Ok();
        }
        catch (ReactionNullException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (ReactionNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError);
        }

    }
}
