using Microsoft.AspNetCore.Authorization;
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
    [AllowAnonymous]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
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

    [HttpPut("update")]
    public ActionResult Update(UpdateArticleDto updateArticle)
    {
        articleService.UpdateAsync(updateArticle);
        return Ok();
    }

    [HttpDelete("delete")]
    public async Task<IActionResult> Delete(int id)
    {
        await articleService.DeleteAsync(id);
        return Ok();
    }
}
