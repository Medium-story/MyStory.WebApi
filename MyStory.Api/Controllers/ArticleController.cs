using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyStory.DTOs.Dtos.ArticleDtos;
using MyStory.Service.Interfaces;

namespace MyStory.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ArticleController(IArticleService articleService) : ControllerBase
{
    private readonly IArticleService articleService = articleService;

    [HttpPost("add")]
    public async Task<IActionResult> AddArticle(AddArticleDto addArticle)
    {
        await articleService.CreateAsync(addArticle);
        return Ok();
    }

    [HttpGet("get-all")]
    public async Task<IActionResult> GetAll()
    {
        var result = await articleService.GetAllAsync();
        return Ok(result);
    }
}
