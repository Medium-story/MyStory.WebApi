using AutoMapper;
using MediumStory.Domain.Entities;
using MyStory.Data.Interfaces;
using MyStory.Domain.Entities;
using MyStory.DTOs.Dtos.ArticleDtos;
using MyStory.DTOs.Dtos.LikeDtos;
using MyStory.Service.Exceptions.LikeException;
using MyStory.Service.Exceptions.UserExceptions;
using MyStory.Service.Interfaces;
using MyStory.Service.Validators;

namespace MyStory.Service.Services;

public class LikeService(IUnitOfWork unitOfWork,
                         IMapper mapper) : ILikeService
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IMapper _mapper = mapper;

    public async Task CreateCommentLikeAsync(AddLikeDto addLikeDto)
    {
        if (addLikeDto == null)
        {
            throw new LikeNullException();
        }

        var like = _mapper.Map<Like>(addLikeDto);

        var likes = await _unitOfWork.Like.GetAllAsync();

        if (like.IsExist(likes))
        {
            var existingLike = likes.FirstOrDefault(l => l.UserId == like.UserId);
            existingLike.User = null;
            existingLike.Comment = null;


            if (existingLike != null)
            {
                _unitOfWork.Like.Delete(existingLike);
                await _unitOfWork.SaveChangesAsync();
            }
        }
        else
        {
            like.Comment = null;
            like.User = null;
            await _unitOfWork.Like.CreateAsync(like);
            await _unitOfWork.SaveChangesAsync();
        }
    }

    public async Task CreateReplyLikeAsync(AddReplyLikeDto addLikeDto)
    {
        if (addLikeDto == null)
        {
            throw new LikeNullException();
        }
        var replyLike = _mapper.Map<ReplyLike>(addLikeDto);
        await _unitOfWork.ReplyLike.CreateAsync(replyLike);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task DeleteAsync(int Id)
    {
        if (Id == null)
        {
            throw new LikeNullException();
        }
        var like = await GetByIdCommentLikeAsync(Id);
        if (like == null)
        {
            throw new LikeNotFoundException();
        }

        like.User = null;
        like.Comment = null;
        _unitOfWork.Like.Delete(like);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task<List<LikeDto>> GetAllCommentLikeAsync()
    {
        var likes = await _unitOfWork.Like.GetAllAsync();
        if (likes == null)
        {
            throw new LikeNullException();
        }
        var likeDtos = likes.Select(i => _mapper.Map<LikeDto>(i)).ToList();
        return likeDtos;
    }

    public async Task<List<ReplyLikeDto>> GetAllReplyLikeAsync()
    {
        var likes = await _unitOfWork.ReplyLike.GetAllAsync();
        if (likes == null)
        {
            throw new LikeNullException();
        }
        var likeDtos = likes.Select(i => _mapper.Map<ReplyLikeDto>(i)).ToList();
        return likeDtos;
    }

    public async Task<Like> GetByIdCommentLikeAsync(int id)
    {
        var like = await _unitOfWork.Like.GetByIdAsync(id);
        if (like == null)
        {
            throw new LikeNullException();
        }
        return like;
    }
}
