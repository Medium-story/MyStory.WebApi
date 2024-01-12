namespace MyStory.DTOs.Dtos.LikeDtos;

public class LikeDto : BaseDto
{
    public int CommentId { get; set; }
    public string UserId { get; set; } = string.Empty;

}
