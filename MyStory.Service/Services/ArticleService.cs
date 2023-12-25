using MyStory.Data.Interfaces;
using MyStory.Service.Interfaces;

namespace MyStory.Service.Services;

public class ArticleService(IUnitOfWork unitOfWork) : IArticleService
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

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

    public Task<ArticleDto> GetByIdAsync(int Id)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(UpdateArticleDto articleDto)
    {
        throw new NotImplementedException();
    }
}
