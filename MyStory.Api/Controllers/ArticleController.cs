using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyStory.DTOs.Dtos.ArticleDtos;
using MyStory.DTOs.UserRoleEnums;
using MyStory.Service.Exceptions.ArticleException;
using MyStory.Service.Interfaces;

namespace MyStory.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ArticleController(IArticleService articleService) : ControllerBase
{
    private readonly IArticleService articleService = articleService;

    [HttpPost("add")]
    //[Authorize(Roles = "User, Admin, SuperAdmin", AuthenticationSchemes = "Bearer")]
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
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> GetAll()
    {
        try
        {
            var result = await articleService.GetAllAsync();
            return Ok(result);
        }
        catch (ArticleNotfoundException ex)
        {
            return StatusCode(204, ex.TitleMessage);
        }
    }

    [HttpGet("get-by-id")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetAllByIdWithEntitesAsync(int id)
    {
        try
        {
            var result = await articleService.GetByIdWithentitiesAsync(id);
            return Ok(result);
        }
        catch (ArticleNotfoundException ex)
        {
            return StatusCode(204, ex.TitleMessage);
        }
    }

    [HttpGet("get-lates")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> GetAllLates()
    {
        try
        {
            var articles = await articleService.GetLatestArticlesAsync();
            return Ok(articles);
        }
        catch(ArticleNotfoundException ex)
        {
            return StatusCode(204, ex.TitleMessage);
        }
    }

    [HttpGet("get-tops")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> GetAllTops()
    {
        try
        {
            var articles = await articleService.GetTopArticlesAsync();
            return Ok(articles);
        }
        catch (ArticleNotfoundException ex)
        {
            return StatusCode(204, ex.TitleMessage);
        }
    }

    [HttpPut("update")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult Update(UpdateArticleDto updateArticle)
    {
        try
        {
            articleService.UpdateAsync(updateArticle);
            return Ok();
        }
        catch(ArticleBadRequestException ex)
        {
            return BadRequest(ex.TitleMessage);
        }
        catch(ArticleNotfoundException ex)
        {
            return NotFound(ex.TitleMessage);
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
            return NotFound(ex.TitleMessage);
        }
        catch(ArticleBadRequestException ex)
        {
            return BadRequest(ex.TitleMessage);
        }
    }
}
