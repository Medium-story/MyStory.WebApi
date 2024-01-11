using AutoMapper;
using MediumStory.Domain.Entities;
using MyStory.Domain.Entities;
using MyStory.DTOs.Dtos.ArticleDtos;
using MyStory.DTOs.Dtos.CommentDtos;
using MyStory.DTOs.Dtos.LikeDtos;
using MyStory.DTOs.Dtos.ReactionDtos;
using MyStory.DTOs.Dtos.ReplyDtos;
using MyStory.DTOs.Dtos.TagDtos;

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

        CreateMap<AddReplyDto, Reply>();
        CreateMap<Reply, ReplyDto>();
        CreateMap<UpdateReplyDto, Reply>();

        CreateMap<AddTagDto, Tag>();
        CreateMap<Tag, TagDto>();
        CreateMap<UpdateTagDto, Tag>();

        CreateMap<AddReactionDto, Reaction>();
        CreateMap<Reaction, ReactionDto>();

        CreateMap<AddReplyLikeDto, ReplyLike>();
        CreateMap<ReplyLike, ReplyLikeDto>();

        CreateMap<AddLikeDto, Like>();
        CreateMap<Like, LikeDto>();
    }
}
