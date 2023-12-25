using MyStory.DTOs.Dtos.TagDtos;

namespace MyStory.Service.Interfaces;

public interface ITagService
{
    Task<List<TagDto>> GetAllAsync();
    Task CreateAsync(AddTagDto articleDto);
    Task UpdateAsync(UpdateTagDto articleDto);
    Task DeleteAsync(int Id);
}
