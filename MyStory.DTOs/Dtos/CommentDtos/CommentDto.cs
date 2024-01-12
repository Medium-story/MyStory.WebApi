using MediumStory.Domain.Entities;
using MyStory.DTOs.Dtos.LikeDtos;
using MyStory.DTOs.Dtos.ReplyDtos;

namespace MyStory.DTOs.Dtos.CommentDtos;

public class CommentDto : BaseDto
{
    public string Content { get; set; } = string.Empty;
    public int ArticleId { get; set; }
    public string UserId { get; set; } = string.Empty;
    public virtual ICollection<ReplyDto> Replies { get; set; } = new List<ReplyDto>();
    public virtual ICollection<LikeDto> CommentLikes { get; set; } = new List<LikeDto>();
    public DateTime CreatedAt { get; set; }

  
}
