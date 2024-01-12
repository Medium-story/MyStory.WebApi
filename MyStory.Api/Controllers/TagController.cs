using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyStory.DTOs.Dtos.TagDtos;
using MyStory.Service.Exceptions.CommentException;
using MyStory.Service.Exceptions.TagExceptions;
using MyStory.Service.Interfaces;
using MyStory.Service.Services;

namespace MyStory.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TagController(ITagService tagService) : ControllerBase
{
    private readonly ITagService _tagService = tagService;

    [HttpPost("add")]
    //[Authorize(Roles = "SuperAdmin, Admin")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> AddTag(AddTagDto addTag)
    {
        try
        {
            await _tagService.CreateAsync(addTag);
            return Ok();
        }
        catch (TagNullException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (TagNotFoundException ex)
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
            var result = await _tagService.GetAllAsync();
            return Ok(result);
        }
        catch (TagNullException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (TagNotFoundException ex)
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
    public async Task<IActionResult> Update(UpdateTagDto updateTag)
    {
        try
        {
            await _tagService.UpdateAsync(updateTag);
            return Ok();
        }
        catch (TagNotFoundException ex)
        {
            return NotFound(ex.TitleMessage);
        }
        catch (TagNullException ex)
        {
            return BadRequest(ex.Message);
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
            await _tagService.DeleteAsync(id);
            return Ok();
        }
        catch (TagNullException ex)
        {
            return BadRequest(ex.TitleMessage);
        }
        catch (TagNotFoundException ex)
        {
            return NotFound(ex.TitleMessage);
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError);
        }

    }
}