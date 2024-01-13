using AutoMapper.Configuration.Annotations;
using MediumStory.Domain.Entities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using MyStory.Service.Interfaces;
namespace MyStory.Service.Services;

public class FileService(IWebHostEnvironment webHostEnvironment,
                       IConfiguration configuration) : IFileService
{
    private readonly IWebHostEnvironment _webHostEnvironment = webHostEnvironment;
    private readonly IConfiguration _configuration = configuration;

    public void Delete(string fileName)
    {
        string filePath = Path.Combine(_webHostEnvironment.WebRootPath, "images", fileName);

        try
        {
            // Faylni o'chirish
            File.Delete(filePath);
        }
        catch (Exception ex)
        {
            throw new Exception($"Xatolik yuz berdi: {ex.Message}");
        }
    }

    public List<string> SaveFile(IFormFile file)
    {
        if (file == null) throw new ArgumentNullException(nameof(file));
        List<string> returns = new();
        string fileName = $"{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";
        string extentiton = fileName.Split('.')[^1];
        List<string> images = new() { "jpg", "svg", "bmo", "png" };
        if (images.Contains(extentiton))
        {
            string filePath = Path.Combine(_webHostEnvironment.WebRootPath, "images", fileName);
            

            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                file.CopyTo(fileStream);
            }

            returns.Add($"{_configuration.GetValue<string>("HostName")}{fileName}");
        }
        else
        {
            throw new AccessViolationException("this format is not supported");
        }

        return returns;
    }
}
