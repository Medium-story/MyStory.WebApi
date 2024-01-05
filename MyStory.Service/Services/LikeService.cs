using AutoMapper;
using MediumStory.Domain.Entities;
using MyStory.Data.Interfaces;
using MyStory.Domain.Entities;
using MyStory.DTOs.Dtos.ArticleDtos;
using MyStory.DTOs.Dtos.LikeDtos;
using MyStory.Service.Interfaces;

namespace MyStory.Service.Services;

public class LikeService(IUnitOfWork unitOfWork,
                         IMapper mapper) : ILikeService
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IMapper _mapper = mapper;

    public async Task CreateCommentLikeAsync(AddLikeDto addLikeDto)
    {
        var like = _mapper.Map<Like>(addLikeDto);
        like.Comment = null;
        like.User = null;
        await _unitOfWork.Like.CreateAsync(like);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task CreateReplyLikeAsync(AddReplyLikeDto addLikeDto)
    {
        var replyLike = _mapper.Map<ReplyLike>(addLikeDto);
        await _unitOfWork.ReplyLike.CreateAsync(replyLike);
        await _unitOfWork.SaveChangesAsync();
    }

    public Task DeleteAsync(int Id)
    {
        throw new NotImplementedException();
    }

    public async Task<List<LikeDto>> GetAllCommentLikeAsync()
    {
        var likes = await _unitOfWork.Like.GetAllAsync();
        var likeDtos = likes.Select(i => _mapper.Map<LikeDto>(i)).ToList();
        return likeDtos;
    }

    public async Task<List<ReplyLikeDto>> GetAllReplyLikeAsync()
    {
        var likes = await _unitOfWork.Like.GetAllAsync();
        var likeDtos = likes.Select(i => _mapper.Map<ReplyLikeDto>(i)).ToList();
        return likeDtos;
    }
}
