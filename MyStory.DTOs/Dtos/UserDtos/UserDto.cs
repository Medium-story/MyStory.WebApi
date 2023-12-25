﻿

using MediumStory.Domain.Entities;
using MyStory.DTOs.Dtos.ArticleDtos;
using MyStory.DTOs.Dtos.CommentDtos;
using MyStory.DTOs.Dtos.LikeDtos;
using MyStory.DTOs.Dtos.ReactionDtos;
using MyStory.DTOs.FollwDtos;

namespace MyStory.DTOs.Dtos.UserDtos;

public class UserDto : BaseDto
{
    public string FullName { get; set; } = string.Empty;
    public string Location { get; set; } = string.Empty;
    public string AvatarUrl { get; set; } = string.Empty;
    public string About { get; set; } = string.Empty;
    public string LinkedIn { get; set; } = string.Empty; 
    public string GitHub { get; set; } = string.Empty;
    public virtual List<Reply> Replies { get; set; } = new List<Reply>();
    public virtual List<CommentDto> Comments { get; set; } = new List<CommentDto>();
    public virtual List<ArticleDto> Articles { get; set; } = new List<ArticleDto>();
    public virtual List<ArticleDto> Saved { get; set; } = new List<ArticleDto>();
    public virtual List<FollowDto> Followers { get; set; } = new List<FollowDto>();
    public virtual List<FollowDto> Following { get; set; } = new List<FollowDto>();
}
