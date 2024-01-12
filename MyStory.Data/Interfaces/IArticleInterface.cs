using MediumStory.Domain.Entities;
using Microsoft.AspNetCore.Http;

namespace MyStory.Data.Interfaces;

public interface IArticleInterface : IRepository<Article>
{
    Task<ICollection<Article>> GetAllWithEntitiesAsync();
    Task<Article> GetByIdWithEntitiesAsync(int id);
    Task<List<Article>> GetLatestArticlesAsync();
    Task<List<Article>> GetToptArticlesAsync();
}
