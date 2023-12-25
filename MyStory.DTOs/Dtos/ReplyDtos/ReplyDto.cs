using MyStory.DTOs.Dtos.LikeDtos;

namespace MyStory.DTOs.Dtos.ReplyDtos;

public class ReplyDto : BaseDto
{
    public string UserId { get; set; } = string.Empty;
    public int CommentId { get; set; }
    public string Content { get; set; } = string.Empty;
    public int ArticleId { get; set; }  
    public virtual List<LikeDto> Likes { get; set; } = new List<LikeDto>();
    public DateTime CreatedAt { get; set; }

}
