using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyStory.DTOs.Dtos.LikeDtos;
using MyStory.Service.Exceptions.LikeException;
using MyStory.Service.Interfaces;

namespace MyStory.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LikeController(ILikeService likeService) : ControllerBase
{
    private readonly ILikeService _likeService = likeService;

    [HttpPost("add-like-to-comment")]
    //[Authorize(Roles = "SuperAdmin, Admin")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> AddCommentLike(AddLikeDto addLikeDto)
    {
        try
        {
            await _likeService.CreateCommentLikeAsync(addLikeDto);
            return Ok();
        }
        catch (LikeNullException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (LikeNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }

    [HttpPost("add-like-to-reply")]
    //[Authorize(Roles = "SuperAdmin, Admin")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> AddReplylike(AddReplyLikeDto addLikeDto)
    {
        try
        {
            await _likeService.CreateReplyLikeAsync(addLikeDto);
            return Ok();
        }
        catch (LikeNullException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (LikeNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }

    [HttpDelete("{id}")]
    //[Authorize(Roles = "SuperAdmin, Admin")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            await _likeService.DeleteAsync(id);
            return Ok();
        }
        catch (LikeNullException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (LikeNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }

    [HttpGet("get-like-of-comment")]
    //[Authorize(Roles = "SuperAdmin, Admin")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetLikeOfComment()
    {
        try
        {
            var result = await _likeService.GetAllCommentLikeAsync();
            return Ok(result);
        }
        catch (LikeNullException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (LikeNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }

    [HttpGet("get-like-of-reply")]
    //[Authorize(Roles = "SuperAdmin, Admin")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetLikeOfReply()
    {
        try
        {
            var result = await _likeService.GetAllReplyLikeAsync();
            return Ok(result);
        }
        catch (LikeNullException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (LikeNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }
}
