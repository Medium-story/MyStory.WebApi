using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyStory.DTOs.Dtos.CommentDtos;
using MyStory.Service.Exceptions.CommentException;
using MyStory.Service.Interfaces;

namespace MyStory.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CommentController(ICommentService commentService) : ControllerBase
{
    private readonly ICommentService commentService = commentService;

    [HttpPost("add")]
    //[Authorize(Roles = "SuperAdmin, Admin")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> AddComment(AddCommentDto addComment)
    {
        try
        {
            await commentService.CreateAsync(addComment);
            return Ok();
        }
        catch (CommentNullException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (CommentNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }

    [HttpGet("get-all")]
    //[Authorize(Roles = "SuperAdmin, Admin")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetAll()
    {
        try
        {
            var comments = await commentService.GetAllAsync();
            return Ok(comments);
        }
        catch (CommentNullException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (CommentNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }

    [HttpGet("{id}")]
    //[Authorize(Roles = "SuperAdmin, Admin")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> getByIdAsync(int id)
    {
        try
        {
            var comment = await commentService.getByIdAsync(id);
            return Ok(comment);
        }
        catch (CommentNullException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (CommentNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }

    [HttpPut("update")]
    //[Authorize(Roles = "SuperAdmin, Admin")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public ActionResult Update(UpdateCommentDto updateComment)
    {
        try
        {
            commentService.UpdateAsync(updateComment);
            return Ok();
        }
        catch (CommentNullException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (CommentNotFoundException ex)
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
            await commentService.DeleteAsync(id);
            return Ok();
        }
        catch (CommentNullException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (CommentNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }
}
