namespace MyStory.DTOs.Dtos.ArticleDtos;

public class UpdateArticleDto : BaseDto
{
    public string FIleUrl { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;
    public string Body { get; set; } = string.Empty;
    public string AverageReadTime => Math.Ceiling((decimal)(Body.Length / 300)).ToString();
    public string UserId { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }

}
