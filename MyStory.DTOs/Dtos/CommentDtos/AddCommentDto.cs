namespace MyStory.DTOs.Dtos.CommentDtos;

public class AddCommentDto
{
    public string Content { get; set; } = string.Empty;
    public int ArticleId { get; set; }
    public string UserId { get; set; } = string.Empty;

}
