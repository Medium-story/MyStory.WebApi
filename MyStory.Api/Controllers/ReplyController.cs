using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyStory.DTOs.Dtos.ReplyDtos;
using MyStory.Service.Interfaces;

namespace MyStory.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ReplyController(IReplyService replyService) : ControllerBase
{
    private readonly IReplyService replyService = replyService;

    [HttpPost("add")]
    public async Task<IActionResult> AddReply(AddReplyDto addReplyDto)
    {
        await replyService.CreateAsync(addReplyDto);
        return Ok();
    }

    [HttpGet("get-all")]
    public async Task<IActionResult> GetAll()
    {
        var result = await replyService.GetAllAsync();
        return Ok(result);
    }
}
