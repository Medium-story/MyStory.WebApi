using MyStory.Service.Interfaces;

namespace MyStory.Service.Services;

public class CommentService : ICommentService

{
    public Task CreateAsync(AddCommentDto commentDto)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(int Id)
    {
        throw new NotImplementedException();
    }

    public Task<List<CommentDto>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<CommentDto> getByIdAsync(int Id)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(UpdateCommentDto commentDto)
    {
        throw new NotImplementedException();
    }
}
