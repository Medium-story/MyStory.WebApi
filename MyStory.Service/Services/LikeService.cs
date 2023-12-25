using MyStory.DTOs.Dtos.ArticleDtos;
using MyStory.Service.Interfaces;

namespace MyStory.Service.Services;

public class LikeService : ILikeService
{
    public Task CreateAsync(AddArticleDto articleDto)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(int Id)
    {
        throw new NotImplementedException();
    }

    public Task<List<ArticleDto>> GetAllAsync()
    {
        throw new NotImplementedException();
    }
}
