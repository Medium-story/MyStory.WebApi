namespace MyStory.DTOs.Dtos.LikeDtos;

public class ReplyLikeDto : BaseDto
{
    public int ReplyId { get; set; }
    public string UserId { get; set; } = string.Empty;

}
