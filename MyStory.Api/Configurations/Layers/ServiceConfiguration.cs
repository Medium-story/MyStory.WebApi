﻿using MediumStory.Data.DataContext;
using MediumStory.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MyStory.Data.Interfaces;
using MyStory.Data.Repositories;
using MyStory.Service.Interfaces;
using MyStory.Service.Services;

namespace MyStory.Api.Configurations.Layers;

public static class ServiceConfiguration
{
    public static void ConfigureService(this WebApplicationBuilder builder)
    {
        builder.Services.AddTransient<IArticleService, ArticleService>();
        builder.Services.AddTransient<ICommentService, CommentService>();
        builder.Services.AddTransient<IReplyService, ReplyService>();
        builder.Services.AddTransient<IReactionService, ReactionService>();
        builder.Services.AddTransient<ILikeService, LikeService>();
        builder.Services.AddTransient<IUserService, UserService>();
        builder.Services.AddTransient<ITagService, TagService>();
        builder.Services.AddTransient<IFileService, FileService>();
    }
}