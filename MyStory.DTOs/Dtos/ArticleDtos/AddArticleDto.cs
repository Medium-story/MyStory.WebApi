namespace MyStory.DTOs.Dtos.ArticleDtos;

public class AddArticleDto
{
    public string FIleUrl { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;
    public string Body { get; set; } = string.Empty;
    public string AverageReadTime => Math.Ceiling((decimal)(Body.Length / 300)).ToString();
    public string UserId { get; set; } = string.Empty;

}
