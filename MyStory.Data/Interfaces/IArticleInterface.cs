using MediumStory.Domain.Entities;

namespace MyStory.Data.Interfaces;

public interface IArticleInterface : IRepository<Article>
{
    Task<ICollection<Article>> GetAllWithEntitiesAsync();
    Task<Article> GetByIdWithEntitiesAsync(int id);
    Task<List<Article>> GetLatestArticlesAsync();
    Task<List<Article>> GetToptArticlesAsync();
}
