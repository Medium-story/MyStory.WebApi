namespace MyStory.Service.Interfaces;

public interface IReplyService
{
    Task<List<ReplyDto>> GetAllAsync();
    Task CreateAsync(AddReplyDto articleDto);
    Task UpdateAsync(UpdateReplyDto articleDto);
    Task DeleteAsync(int Id);
}
