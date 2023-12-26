using AutoMapper;
using MediumStory.Domain.Entities;
using MyStory.Data.Interfaces;
using MyStory.DTOs.Dtos.ArticleDtos;
using MyStory.Service.Interfaces;

namespace MyStory.Service.Services;

public class ArticleService(IUnitOfWork unitOfWork,
                            IMapper mapper) : IArticleService
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IMapper _mapper = mapper;

    public async Task CreateAsync(AddArticleDto articleDto)
    {
        var article = _mapper.Map<Article>(articleDto);
        await _unitOfWork.Article.CreateAsync(article);
        await _unitOfWork.SaveChangesAsync();
    }

    public Task DeleteAsync(int Id)
    {
        throw new NotImplementedException();
    }

    public async Task<List<ArticleDto>> GetAllAsync()
    {
        var article = await _unitOfWork.Article.GetAllWithEntities();
        var articleDtos = article.Select(i => _mapper.Map<ArticleDto>(i)).ToList();
        return articleDtos;
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
