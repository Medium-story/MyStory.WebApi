using Microsoft.AspNetCore.Http;

namespace MyStory.Service.Interfaces;

public interface IFileService
{
    List<string> SaveFile(IFormFile file);
    void Delete(string fileName);
}
