using MyStory.DTOs.Dtos.CommentDtos;
using MyStory.DTOs.Dtos.ReactionDtos;
using MyStory.DTOs.Dtos.ReplyDtos;
using MyStory.DTOs.Dtos.UserDtos;

namespace MyStory.DTOs.Dtos.ArticleDtos;

public class ArticleDto : BaseDto
{
    public string FIleUrl { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;
    public string Body { get; set; } = string.Empty;
    public string AverageReadTime => Math.Ceiling((decimal)(Body.Length / 300)).ToString();
    public string UserId { get; set; } = string.Empty;
    public virtual ICollection<ReactionDto> Reactions { get; set; } = new List<ReactionDto>();
    public virtual ICollection<CommentDto> Comments { get; set; } = new List<CommentDto>();
    public virtual ICollection<UserDto> Users { get; set; } = new List<UserDto>();
    public DateTime CreatedAt { get; set; }

}
