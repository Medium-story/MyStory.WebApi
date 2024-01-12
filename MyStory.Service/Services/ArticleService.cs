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
        var article = await _unitOfWork.Article.GetByIdWithEntitiesAsync(Id);
        if (article == null)
        {
            throw new ArticleNotfoundException();
        }
        _unitOfWork.Article.Delete(article);

        await _unitOfWork.SaveChangesAsync();
    }

    public async Task<List<ArticleDto>> GetAllAsync()
    {
        var articles = await _unitOfWork.Article.GetAllWithEntitiesAsync();

        if (articles.Count() == 0)
        {
            throw new ArticleNotfoundException("No articles available");
        }
        var articleDtos = articles.Select(i => _mapper.Map<ArticleDto>(i)).ToList();
        return articleDtos;
    }

    public async Task<ArticleDto> GetByIdWithentitiesAsync(int Id)
    {
        var article = await _unitOfWork.Article.GetByIdWithEntitiesAsync(Id);
        if (article == null)
        {
            throw new ArticleNotfoundException();
        }
        var articleDto = _mapper.Map<ArticleDto>(article);
        return articleDto;
    }

    public async Task<List<ArticleDto>> GetLatestArticlesAsync()
    {
        var articles = await _unitOfWork.Article.GetLatestArticlesAsync();

        if (articles.Count() == 0)
        {
            throw new ArticleNotfoundException("No articles available");
        }
        var result = articles.Select(i => _mapper.Map<ArticleDto>(i)).ToList();
        return result;
    }

    public async Task<List<ArticleDto>> GetTopArticlesAsync()
    {
        var articles = await _unitOfWork.Article.GetToptArticlesAsync();
        if (articles.Count() == 0)
        {
            throw new ArticleNotfoundException("No articles available");
        }
        var result = articles.Select(i => _mapper.Map<ArticleDto>(i)).ToList();
        return result;
    }

    public async Task UpdateAsync(UpdateArticleDto articleDto)
    {
        var articelDto = await GetByIdWithentitiesAsync(articleDto.Id);
        if (articleDto is null)
        {
            throw new ArticleNotfoundException("Bunday Id li article mavjud emas");
        }
        var article = _mapper.Map<Article>(articleDto);
        article.User = null;
        if (article == null)
        {
            throw new ArticleBadRequestException("An error occurred while updating");
        }
        _unitOfWork.Article.Update(article);
        await _unitOfWork.SaveChangesAsync();
    }
}