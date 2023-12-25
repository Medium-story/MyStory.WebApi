using MyStory.DTOs.Dtos.ReactionDtos;
using MyStory.Service.Interfaces;

namespace MyStory.Service.Services;

public class ReactionService : IReactionService
{
    public Task CreateAsync(AddReactionDto articleDto)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(int Id)
    {
        throw new NotImplementedException();
    }

    public Task<List<ReactionDto>> GetAllAsync()
    {
        throw new NotImplementedException();
    }
}
