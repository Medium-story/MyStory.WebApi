using MyStory.DTOs.Dtos.TagDtos;
using MyStory.Service.Interfaces;

namespace MyStory.Service.Services;

public class TagService : ITagService
{
    public Task CreateAsync(AddTagDto articleDto)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(int Id)
    {
        throw new NotImplementedException();
    }

    public Task<List<TagDto>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(UpdateTagDto articleDto)
    {
        throw new NotImplementedException();
    }
}
