namespace MyStory.Service.Exceptions.ArticleException;

public class ArticleBadRequestException : BadRequestException
{
    public string errorMessage { get; set; }
    public ArticleBadRequestException()
    {
        errorMessage = "Article creation failed! Check article details and try again.";
    }

    public ArticleBadRequestException(string errorText)
    {
        errorMessage = errorText;
    }
}
