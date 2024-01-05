using Microsoft.AspNetCore.Mvc;
using MyStory.DTOs.Dtos.LikeDtos;
using MyStory.Service.Interfaces;

namespace MyStory.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LikeController(ILikeService likeService) : ControllerBase
{
    private readonly ILikeService _likeService = likeService;

    [HttpPost("add-like-to-comment")]
    public async Task<IActionResult> AddCommentLike(AddLikeDto addLikeDto)
    {
        await _likeService.CreateCommentLikeAsync(addLikeDto);
        return Ok();
    }

    [HttpPost("add-like-to-reply")]
    public async Task<IActionResult> AddReplylike(AddReplyLikeDto addLikeDto)
    {
        await _likeService.CreateReplyLikeAsync(addLikeDto);
        return Ok();
    }
}
