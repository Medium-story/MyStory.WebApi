namespace MyStory.Service.Interfaces;

public interface ITagService
{
    Task<List<TagDto>> GetAllAsync();
    Task CreateAsync(AddtagDto articleDto);
    Task UpdateAsync(UpdateTagDto articleDto);
    Task DeleteAsync(int Id);
}
