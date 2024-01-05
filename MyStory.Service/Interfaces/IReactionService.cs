using MyStory.DTOs.Dtos.ReactionDtos;

namespace MyStory.Service.Interfaces;

public interface IReactionService
{
    Task<List<ReactionDto>> GetAllAsync();
    Task CreateAsync(AddReactionDto reactionDto);
    Task DeleteAsync(int Id);
}
