using MyStory.DTOs.Dtos.ArticleDtos;
using MyStory.DTOs.Dtos.LikeDtos;

namespace MyStory.Service.Interfaces;

public interface ILikeService
{
    Task<List<LikeDto>> GetAllCommentLikeAsync();
    Task<List<ReplyLikeDto>> GetAllReplyLikeAsync();
    Task CreateCommentLikeAsync(AddLikeDto addLikeDto);
    Task CreateReplyLikeAsync(AddReplyLikeDto addreplyLikeDto);
    Task DeleteAsync(int Id);
}
