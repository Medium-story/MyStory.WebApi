using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyStory.DTOs.Dtos.ArticleDtos;
using MyStory.Service.Exceptions.ArticleException;
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
        try
        {
            await articleService.CreateAsync(addArticle);
            return Ok();
        }
        catch(ArticleNullException ex)
        {
            return BadRequest(ex);
        }
    }

    [HttpGet("get-all")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetAll()
    {
        try
        {
            var result = await articleService.GetAllAsync();
            return Ok(result);
        }
        catch(ArticleBadRequestException ex)
        {
            return BadRequest(ex);
        }
    }

    [HttpPut("update")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public ActionResult Update(UpdateArticleDto updateArticle)
    {
        try
        {
            articleService.UpdateAsync(updateArticle);
            return Ok();
        }
        catch(ArticleBadRequestException ex)
        {
            return BadRequest(ex);
        }
    }

    [HttpDelete("delete")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            await articleService.DeleteAsync(id);
            return Ok();
        }
        catch(ArticleNotfoundException ex)
        {
            return NotFound(ex);
        }
        catch(ArticleBadRequestException ex)
        {
            return BadRequest(ex);
        }
    }
}
