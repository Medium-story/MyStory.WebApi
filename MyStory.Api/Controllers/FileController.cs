using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using MyStory.Service.Interfaces;

namespace MyStory.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FileController(IFileService fileService) : ControllerBase
{
    private readonly IFileService _file = fileService;

    [HttpPost("upload")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult Upload(IFormFile file)
    {
        try
        {
            List<string> fileName = _file.SaveFile(file);
            return Ok(fileName);
        }
        catch (AccessViolationException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (ArgumentNullException ex)
        {
            return NotFound(ex.Message);
        }
    }

    [HttpDelete("delete")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult Delete(string filePath) 
    {
        try
        {
            _file.Delete(filePath);
            return Ok();
        }
        catch (AccessViolationException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (ArgumentNullException ex)
        {
            return NotFound(ex.Message);
        }
    }
}
