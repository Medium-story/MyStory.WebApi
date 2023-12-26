using AutoMapper;
using MediumStory.Domain.Entities;
using MyStory.DTOs.Dtos.ArticleDtos;
using MyStory.DTOs.Dtos.CommentDtos;

namespace MyStory.DTOs;

public class MyMapper : Profile
{
    public MyMapper()
    {
        CreateMap<AddArticleDto, Article>();
        CreateMap<Article, ArticleDto>();
        CreateMap<UpdateArticleDto, Article>();

        CreateMap<AddCommentDto, Comment>();
        CreateMap<Comment, CommentDto>();
        CreateMap<UpdateCommentDto, Comment>();
    }
}
