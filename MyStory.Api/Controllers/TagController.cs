using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyStory.DTOs.Dtos.TagDtos;
using MyStory.Service.Interfaces;
using MyStory.Service.Services;

namespace MyStory.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TagController(ITagService tagService) : ControllerBase
{
    private readonly ITagService _tagService = tagService;

    [HttpPost("add")]
    public async Task<IActionResult> AddTag(AddTagDto addTag)
    {
        await _tagService.CreateAsync(addTag);
        return Ok();
    }

    [HttpGet("get-all")]
    public async Task<IActionResult> GetAll()
    {
        var result = await _tagService.GetAllAsync();
        return Ok(result);
    }

    [HttpPut("update")]
    public ActionResult Update(UpdateTagDto updateTag)
    {
        _tagService.UpdateAsync(updateTag);
        return Ok();
    }

    [HttpDelete("delete")]
    public async Task<IActionResult> Delete(int id)
    {
        await _tagService.DeleteAsync(id);
        return Ok();
    }
}