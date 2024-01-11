using AutoMapper;
using MediumStory.Domain.Entities;
using MyStory.Data.Interfaces;
using MyStory.DTOs.Dtos.ArticleDtos;
using MyStory.Service.Exceptions.ArticleException;
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
        article.User = null;
        if (article == null)
        {
            throw new ArticleNullException();
        }
        await _unitOfWork.Article.CreateAsync(article);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task DeleteAsync(int Id)
    {
        var article = await _unitOfWork.Article.GetByIdWithEntities(Id);
        if (article == null)
        {
            throw new ArticleNotfoundException();
        }
        _unitOfWork.Article.Delete(article);

        await _unitOfWork.SaveChangesAsync();
    }

    public async Task<List<ArticleDto>> GetAllAsync()
    {
        var article = await _unitOfWork.Article.GetAllWithEntities();
        var articleDtos = article.Select(i => _mapper.Map<ArticleDto>(i)).ToList();
        return articleDtos;
    }

    public async Task<ArticleDto> GetByIdAsync(int Id)
    {
        var article = await _unitOfWork.Article.GetByIdWithEntities(Id);
        var articleDto = _mapper.Map<ArticleDto>(article);
        return articleDto;
    }

    public async Task UpdateAsync(UpdateArticleDto articleDto)
    {
        var article = _mapper.Map<Article>(articleDto);
        article.User = null;
        _unitOfWork.Article.Update(article);
        await _unitOfWork.SaveChangesAsync();
    }
}
