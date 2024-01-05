using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyStory.DTOs.Dtos.ReactionDtos;
using MyStory.Service.Interfaces;

namespace MyStory.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ReactionController(IReactionService reactionService) : ControllerBase
{
    private readonly IReactionService _reactionService = reactionService;

    [HttpPost("add-reactive")]
    public async Task<IActionResult> AddReaction(AddReactionDto reactionDto)
    {
        await _reactionService.CreateAsync(reactionDto);
        return Ok();
    }

    [HttpGet("get-all-reaction")]
    public async Task<IActionResult> Getall()
    {
        var reactions = await _reactionService.GetAllAsync();
        return Ok(reactions);
    }
}
