using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyStory.DTOs.Dtos.ReplyDtos;
using MyStory.DTOs.Dtos.TagDtos;
using MyStory.Service.Exceptions.ReplyException;
using MyStory.Service.Exceptions.TagExceptions;
using MyStory.Service.Interfaces;
using MyStory.Service.Services;

namespace MyStory.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ReplyController(IReplyService replyService) : ControllerBase
{
    private readonly IReplyService replyService = replyService;

    [HttpPost("add")]
    //[Authorize(Roles = "SuperAdmin, Admin")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> AddReply(AddReplyDto addReplyDto)
    {
        try
        {
            await replyService.CreateAsync(addReplyDto);
            return Ok();
        }
        catch (ReplyNullException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (ReplyNotFoundException ex)
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
            var result = await replyService.GetAllAsync();
            return Ok(result);
        }
        catch (ReplyNullException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (ReplyNotFoundException ex)
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
    public ActionResult Update(UpdateReplyDto updateReply)
    {
        try
        {
            replyService.UpdateAsync(updateReply);
            return Ok();
        }
        catch (ReplyNullException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (ReplyNotFoundException ex)
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
            await replyService.DeleteAsync(id);
            return Ok();
        }
        catch (ReplyNullException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (ReplyNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError);
        }

    }
}
