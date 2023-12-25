namespace MyStory.Service.Interfaces;

public interface ILikeService
{
    Task<List<ArticleDto>> GetAllAsync();
    Task CreateAsync(AddArticleDto articleDto);
    Task DeleteAsync(int Id);
}
