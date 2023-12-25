using MyStory.Service.Interfaces;

namespace MyStory.Service.Services;

public class ReplyService : IReplyService
{
    public Task CreateAsync(AddReplyDto articleDto)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(int Id)
    {
        throw new NotImplementedException();
    }

    public Task<List<ReplyDto>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(UpdateReplyDto articleDto)
    {
        throw new NotImplementedException();
    }
}
