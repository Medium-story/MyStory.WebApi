using MyStory.DTOs.Dtos.CommentDtos;

namespace MyStory.Service.Interfaces;

public interface ICommentService
{
    Task<List<CommentDto>> GetAllAsync();
    Task<CommentDto> getByIdAsync(int Id);
    Task CreateAsync(AddCommentDto commentDto);
    Task UpdateAsync(UpdateCommentDto commentDto);
    Task DeleteAsync(int Id);
}
