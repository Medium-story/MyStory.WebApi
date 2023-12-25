using MediumStory.Domain.Enums;

namespace MyStory.DTOs.Dtos.ReactionDtos;

public class ReactionDto : BaseDto
{
    public int ArticleId { get; set; }
    public string UserId { get; set; } = string.Empty;
    public ReactionEnum Type { get; set; } 

}
