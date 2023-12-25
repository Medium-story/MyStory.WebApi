namespace MyStory.DTOs.Dtos.ReplyDtos;

public class AddReplyDto
{
    public string UserId { get; set; } = string.Empty;
    public int CommentId { get; set; }
    public string Content { get; set; } = string.Empty;
    public int ArticleId { get; set; }
    public DateTime CreatedAt { get; set; }

}
