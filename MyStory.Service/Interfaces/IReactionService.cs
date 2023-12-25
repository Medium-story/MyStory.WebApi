namespace MyStory.Service.Interfaces;

public interface IReactionService
{
    Task<List<ReactionDto>> GetAllAsync();
    Task CreateAsync(AddReactionDto articleDto);
    Task DeleteAsync(int Id);
}
