using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyStory.DTOs.Dtos.CommentDtos;
using MyStory.Service.Interfaces;

namespace MyStory.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CommentController(ICommentService commentService) : ControllerBase
{
    private readonly ICommentService commentService = commentService;

    [HttpPost("add")]
    public async Task<IActionResult> AddComment(AddCommentDto addComment)
    {
        await commentService.CreateAsync(addComment);
        return Ok();
    }

    [HttpGet("get-all")]
    public async Task<IActionResult> GetAll()
    {
        var comments = await commentService.GetAllAsync();
        return Ok(comments);
    }
}
