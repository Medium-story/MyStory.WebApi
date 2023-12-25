namespace MyStory.DTOs.Dtos.LikeDtos;

public class AddLikeDto : BaseDto
{
    public int CommentId { get; set; }
    public int ReplyId { get; set; }
    public string UserId { get; set; } = string.Empty;

}
