using MyStory.DTOs.Dtos.ArticleDtos;

namespace MyStory.Service.Interfaces;

public interface IArticleService
{
    Task<List<ArticleDto>> GetAllAsync();
    Task<ArticleDto> GetByIdAsync(int Id);
    Task CreateAsync(AddArticleDto articleDto);
    Task UpdateAsync(UpdateArticleDto articleDto);
    Task DeleteAsync(int Id);
}
